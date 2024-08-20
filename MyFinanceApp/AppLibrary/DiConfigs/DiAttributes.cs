using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Defines custom attributes used to mark classes for specific service lifetimes in the dependency injection (DI) container
namespace System
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TransientServiceAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SingletonServiceAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ScopedServiceAttribute : Attribute
    {
    }
}
