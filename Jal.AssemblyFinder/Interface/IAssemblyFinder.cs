using System;
using System.Reflection;

namespace Jal.AssemblyFinder.Interface
{
    public interface IAssemblyFinder
    {
        Assembly[] GetAssemblies();

        Assembly[] GetAssemblies(string autoRegisterName);

        Assembly GetAssembly(string autoRegisterName);

        T[] GetInstancesOf<T>(Assembly[] assemblies);

        Type[] GetTypesOf<T>(Assembly[] assemblies);
    }
}