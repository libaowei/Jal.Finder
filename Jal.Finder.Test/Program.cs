using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jal.Finder.Impl;

namespace Jal.Finder.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = AssemblyFinder.Builder.UsePath(AppDomain.CurrentDomain.BaseDirectory).Create;
            var a = f.GetAssemblies();
            var b = f.GetAssemblies(x => x.FullName == "");
        }
    }
}
