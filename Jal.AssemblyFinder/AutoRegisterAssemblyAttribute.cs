using System;

namespace Jal.AssemblyFinder
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class AutoRegisterAssemblyAttribute : Attribute
    {
        public string Name { get; set; }

        public AutoRegisterAssemblyAttribute()
        {
            Name = GetType().Name;
        }

        public AutoRegisterAssemblyAttribute(string name)
        {
            Name = name;
        }
    }
}