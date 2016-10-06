using System;
using Jal.Finder.Fluent.Interface;
using Jal.Finder.Interface;

namespace Jal.Finder.Fluent.Impl
{
    public class AssemblyFinderFluentBuilder: IAssemblyFinderEndFluentBuilder, IAssemblyFinderStartFluentBuilder
    {
        public string Path;

        public IAssemblyFinder Create
        {
            get { return new Finder.Impl.AssemblyFinder(Path); }
        }

        public IAssemblyFinderEndFluentBuilder UsePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(nameof(path));
            }

            Path = path;

            return this;
        }
    }
}
