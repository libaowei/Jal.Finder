using Jal.Finder.Fluent.Interface;
using Jal.Finder.Interface;

namespace Jal.Finder.Fluent.Impl
{
    public class AssemblyFinderFluentBuilder: IAssemblyFinderEndFluentBuilder, IAssemblyFinderStartFluentBuilder
    {
        private string _path;

        public IAssemblyFinder Create
        {
            get { return new Finder.Impl.AssemblyFinder(_path); }
        }

        public IAssemblyFinderEndFluentBuilder UsePath(string path)
        {
            _path = path;
            return this;
        }
    }
}
