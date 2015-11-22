using System;

namespace Jal.AssemblyFinder
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class AssemblyTagAttribute : Attribute
    {
        public string Name { get; set; }

        public AssemblyTagAttribute()
        {
            Name = GetType().Name;
        }

        public AssemblyTagAttribute(string name)
        {
            Name = name;
        }
    }
}