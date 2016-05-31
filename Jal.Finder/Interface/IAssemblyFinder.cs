using System.Reflection;

namespace Jal.Finder.Interface
{
    public interface IAssemblyFinder
    {
        Assembly[] GetAssemblies();

        Assembly[] GetAssemblies(string tag);

        Assembly GetAssembly(string tag);

        //T[] GetInstancesOf<T>(Assembly[] assemblies);

        //Type[] GetTypesOf<T>(Assembly[] assemblies);
    }
}