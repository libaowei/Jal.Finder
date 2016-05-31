using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Jal.Finder.Atrribute;
using Jal.Finder.Fluent.Impl;
using Jal.Finder.Fluent.Interface;
using Jal.Finder.Interface;

namespace Jal.Finder.Impl
{
    public class AssemblyFinder : IAssemblyFinder
    {
        public static IAssemblyFinder Current;

        public static IAssemblyFinderStartFluentBuilder Builder
        {
            get
            {
                return new AssemblyFinderFluentBuilder();
            }
        }

        private readonly string _directoryPath;

        public AssemblyFinder(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public Assembly[] GetAssemblies()
        {
            var assemblyFiles = from file in Directory.GetFiles(_directoryPath)
                                where ((file.Contains(".dll") || file.Contains(".exe")) && !file.Contains(".config"))
                                select file;
            return assemblyFiles.Select(Assembly.LoadFrom).ToArray();
        }

        public Assembly[] GetAssemblies(string tag)
        {
            var assemblies = GetAssemblies();
            var filteredAssemblies = new List<Assembly>();
            foreach (var assembly in assemblies)
            {
                var attributes = assembly.GetCustomAttributes(typeof(AssemblyTagAttribute), false);
                if (attributes.Length > 0)
                {
                    foreach (var o in attributes)
                    {
                        var attribute = o as AssemblyTagAttribute;
                        if (attribute != null && attribute.Name == tag)
                        {
                            filteredAssemblies.Add(assembly);
                        }
                    }
                }
            }

            return filteredAssemblies.ToArray();
        }

        public Assembly GetAssembly(string tag)
        {
            var assemblies = GetAssemblies(tag);
            return assemblies.FirstOrDefault();
        }

        //public T[] GetInstancesOf<T>(Assembly[] assemblies)
        //{
        //    var type = typeof (T);
        //    var instances = new List<T>();
        //    foreach (var assembly in assemblies)
        //    {
        //        var assemblyInstance = (
        //            assembly.GetTypes()
        //            .Where(t => type.IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
        //            .Select(Activator.CreateInstance)
        //            .Cast<T>()
        //            ).ToArray();
        //        instances.AddRange(assemblyInstance);
        //    }
        //    return instances.ToArray();
        //}

        //public Type[] GetTypesOf<T>(Assembly[] assemblies)
        //{
        //    var type = typeof(T);
        //    var instances = new List<Type>();
        //    foreach (var assembly in assemblies)
        //    {
        //        var assemblyInstance = (
        //            assembly.GetTypes()
        //            .Where(t => type.IsAssignableFrom(t))
        //            ).ToArray();
        //        instances.AddRange(assemblyInstance);
        //    }
        //    return instances.ToArray();
        //}
    }
}