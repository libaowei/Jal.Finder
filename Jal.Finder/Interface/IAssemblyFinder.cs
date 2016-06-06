using System;
using System.Reflection;

namespace Jal.Finder.Interface
{
    public interface IAssemblyFinder
    {
        Assembly[] GetAssemblies();

        Assembly[] GetAssembliesTagged<TTag>() where TTag : Attribute;

        Assembly[] GetAssembliesTagged<TTag>(Func<TTag, bool> statement) where TTag : Attribute;

        Assembly[] GetAssemblies(Func<Assembly, bool> statement);
    }
}