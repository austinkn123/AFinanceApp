using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
