# Jal.Finder [![Build status](https://ci.appveyor.com/api/projects/status/riewcxw29gy77855/branch/master?svg=true)](https://ci.appveyor.com/project/raulnq/jal-assemblyfinder/branch/master) [![NuGet](https://img.shields.io/nuget/v/Jal.Finder.svg)](https://www.nuget.org/packages/Jal.Finder) 

Just another library to find stuffs

## How to use?

### Assemblies

Tag your assembly adding the next attribute in your AssemblyInfo.cs file:

    [assembly: AssemblyTag("Tag")]
    
Initiate the finder

    var directory = AppDomain.CurrentDomain.BaseDirectory;

    var finder = AssemblyFinder.Create(directory);
    
Search the assemblies

    var assemblies1 = f.GetAssembliesTagged<AssemblyTagAttribute>(x => x.Name == "Tag");

	var assemblies2 = f.GetAssembliesTagged<AssemblyTagAttribute>();
    
	var assemblies3 = f.GetAssemblies();

	var assemblies4 = f.GetAssemblies(x => x.FullName.Contains("Test"));






