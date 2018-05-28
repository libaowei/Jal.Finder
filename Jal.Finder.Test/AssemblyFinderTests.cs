using System;
using Jal.Finder.Atrribute;
using Jal.Finder.Impl;
using NUnit.Framework;
using Shouldly;

namespace Jal.Finder.Test
{
    [TestFixture]
    public class AssemblyFinderTests
    {
        [Test]
        public void GetAssemblies_With_ShouldNotBeEmpty()
        {
            var sut = AssemblyFinder.Create(AppDomain.CurrentDomain.BaseDirectory);

            var assemblies = sut.GetAssemblies();

            assemblies.ShouldNotBeEmpty();
        }

        [Test]
        public void GetAssemblies_WithStatement_ShouldNotBeEmpty()
        {
            var sut = new AssemblyFinder(AppDomain.CurrentDomain.BaseDirectory);

            var assemblies = sut.GetAssemblies(x=>x.FullName.Contains("Jal.Finder"));

            assemblies.ShouldNotBeEmpty();
        }

        [Test]
        public void GetAssembliesTagged_With_ShouldNotBeEmpty()
        {
            var sut = new AssemblyFinder(AppDomain.CurrentDomain.BaseDirectory);

            var assemblies = sut.GetAssembliesTagged<AssemblyTagAttribute>();

            assemblies.ShouldNotBeEmpty();
        }

        [Test]
        public void GetAssembliesTagged_WithStatement_ShouldNotBeEmpty()
        {
            var sut = new AssemblyFinder(AppDomain.CurrentDomain.BaseDirectory);

            var assemblies = sut.GetAssembliesTagged<AssemblyTagAttribute>(x=>x.Name=="Test");

            assemblies.ShouldNotBeEmpty();
        }
    }
}
