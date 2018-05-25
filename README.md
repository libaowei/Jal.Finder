# Jal.Finder
Just another library to find assemblies

## How to use?
Tag your assembly adding the next attribute in your AssemblyInfo.cs file:

    [assembly: AssemblyTag("Tag")]
    
Initiate the finder

    var directory = AppDomain.CurrentDomain.BaseDirectory;

    finder = AssemblyFinder.Builder.UsePath(directory).Create;
    
Search the assemblies

    var assemblies1 = f.GetAssembliesTagged<AssemblyTagAttribute>(x => x.Name == "Tag");

	var assemblies2 = f.GetAssembliesTagged<AssemblyTagAttribute>();
    
	var assemblies3 = f.GetAssemblies();

	var assemblies4 = f.GetAssemblies(x => x.FullName.Contains("Test"));

[![Build status](https://ci.appveyor.com/api/projects/status/riewcxw29gy77855/branch/master?svg=true)](https://ci.appveyor.com/project/raulnq/jal-assemblyfinder/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Jal.Finder.svg)](https://www.nuget.org/packages/Jal.Finder) 





