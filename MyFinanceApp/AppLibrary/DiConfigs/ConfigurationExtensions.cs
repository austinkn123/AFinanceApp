﻿using System.Reflection;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static T GetSectionAs<T>(this IConfiguration config, string name) where T : class
        {
            var section = config.GetSection(name);
            if (section.Exists())
            {
                return section.Get<T>();
            }

            return null;
        }

        public static string FromValuesOrRoot(this IConfiguration config, string name, string def = null)
        {
            // look for values:name (local function app or settings), then name (deployed function app)
            return config[$"Values:{name}"] ?? config[name] ?? def;
        }


        public static T FromValuesOrRoot<T>(this IConfiguration config, string name, T def)
        {
            // look for values:name (local function app or settings), then name (deployed function app)
            return config.GetValue<T>($"Values:{name}") ?? config.GetValue<T>(name) ?? def;
        }

        /// <summary>
        /// Uses reflection to set the properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configuration"></param>
        /// <param name="target"></param>
        /// <param name="propsToSkip"></param>
        public static void SetProps<T>(this IConfiguration configuration, T target, params string[] propsToSkip)
        {
            // only grab properties declared on the type
            typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(prop => !propsToSkip.Contains(prop.Name))
                .ForEach(prop =>
                {
                    if (prop.SetMethod == null) return; // readonly property

                    var propType = prop.PropertyType;
                    if (propType == typeof(string))
                        prop.SetMethod.Invoke(target, new object[] { configuration.FromValuesOrRoot(prop.Name) });
                    else if (propType == typeof(bool))
                        prop.SetMethod.Invoke(target, new object[] { EmptyToFalse(configuration.FromValuesOrRoot(prop.Name)) });
                    else if (propType == typeof(string[]))
                        prop.SetMethod.Invoke(target, new object[] { Split(configuration.FromValuesOrRoot(prop.Name)) });
                    else if (propType == typeof(int))
                        prop.SetMethod.Invoke(target, new object[] { configuration.FromValuesOrRoot<int>(prop.Name, 0) });
                    else if (propType == typeof(double))
                        prop.SetMethod.Invoke(target, new object[] { configuration.FromValuesOrRoot<double>(prop.Name, 0.0) });
                    else if (propType == typeof(Dictionary<string, string>))
                        prop.SetMethod.Invoke(target, new object[] { GetSectionAs<Dictionary<string, string>>(configuration, prop.Name) ?? new() });
                    else if (propType == typeof(Dictionary<string, int>))
                        prop.SetMethod.Invoke(target, new object[] { GetSectionAs<Dictionary<string, int>>(configuration, prop.Name) ?? new() });
                });
        }

        private static string[] Split(string s) => string.IsNullOrEmpty(s) ? Array.Empty<string>() : s.Split(',', StringSplitOptions.RemoveEmptyEntries);
        // configuration.GetValue uses the default if the key is missing, not if it is empty
        private static bool EmptyToFalse(string s) => !string.IsNullOrEmpty(s) && Convert.ToBoolean(s);
    }
}