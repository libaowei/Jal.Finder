using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Jal.AssemblyFinder.Interface;

namespace Jal.AssemblyFinder.Impl
{
    public class AssemblyFinder : IAssemblyFinder
    {
        public static IAssemblyFinder Current
        {
            get; set;
        }

        private readonly string _directoryPath;

        public AssemblyFinder(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public Assembly[] GetAssemblies()
        {
            var assemblyFiles = from file in Directory.GetFiles(_directoryPath)
                                where (file.Contains(".dll") && !file.Contains(".config"))
                                select file;
            return assemblyFiles.Select(Assembly.LoadFrom).ToArray();
        }

        public Assembly[] GetAssemblies(string autoRegisterName)
        {
            var assemblies = GetAssemblies();
            var filteredAssemblies = new List<Assembly>();
            foreach (var assembly in assemblies)
            {
                var attributes = assembly.GetCustomAttributes(typeof(AutoRegisterAssemblyAttribute), false);
                if (attributes.Length > 0)
                {
                    foreach (var o in attributes)
                    {
                        var attribute = o as AutoRegisterAssemblyAttribute;
                        if (attribute != null && attribute.Name == autoRegisterName)
                        {
                            filteredAssemblies.Add(assembly);
                        }
                    }
                }
            }

            return filteredAssemblies.ToArray();
        }

        public Assembly GetAssembly(string autoRegisterName)
        {
            var assemblies = GetAssemblies(autoRegisterName);
            return assemblies.FirstOrDefault();
        }

        public T[] GetInstancesOf<T>(Assembly[] assemblies)
        {
            var type = typeof (T);
            var instances = new List<T>();
            foreach (var assembly in assemblies)
            {
                var assemblyInstance = (
                    assembly.GetTypes()
                    .Where(t => type.IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                    .Select(Activator.CreateInstance)
                    .Cast<T>()
                    ).ToArray();
                instances.AddRange(assemblyInstance);
            }
            return instances.ToArray();
        }
    }
}