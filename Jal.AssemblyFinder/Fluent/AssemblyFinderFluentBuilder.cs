using Jal.AssemblyFinder.Interface;
using Jal.AssemblyFinder.Interface.Fluent;

namespace Jal.AssemblyFinder.Fluent
{
    public class AssemblyFinderFluentBuilder: IAssemblyFinderEndFluentBuilder, IAssemblyFinderStartFluentBuilder
    {
        private string _path;

        public IAssemblyFinder Create
        {
            get { return new Impl.AssemblyFinder(_path); }
        }

        public IAssemblyFinderEndFluentBuilder UsePath(string path)
        {
            _path = path;
            return this;
        }
    }
}
