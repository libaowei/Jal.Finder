using System;
using Jal.Finder.Fluent.Impl;
using Jal.Finder.Fluent.Interface;
using Jal.Finder.Interface;
using NUnit.Framework;
using Shouldly;

namespace Jal.Finder.Test
{
    [TestFixture]
    public class AssemblyFinderFluentBuilderTests
    {

        [Test]
        public void UsePath_With_ShouldNotBeEmpty()
        {
            var sut = new AssemblyFinderFluentBuilder();

            var chain = sut.UsePath("Test");

            chain.ShouldNotBeNull();

            chain.ShouldBeAssignableTo<IAssemblyFinderEndFluentBuilder>();

            sut.Path.ShouldBe("Test");
        }

        [Test]
        public void UsePath_WithNullValue_ShouldNotBeEmpty()
        {
            var sut = new AssemblyFinderFluentBuilder();

            Should.Throw<ArgumentException>(()=> { var chain = sut.UsePath(null); }) ;
        }

        [Test]
        public void Create_With_ShouldNotBeEmpty()
        {
            var sut = new AssemblyFinderFluentBuilder();

            var instance = sut.UsePath("Test").Create;

            instance.ShouldNotBeNull();

            instance.ShouldBeAssignableTo<IAssemblyFinder>();

            sut.Path.ShouldBe("Test");
        }
    }
}