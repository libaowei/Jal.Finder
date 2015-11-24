# Jal.AssemblyFinder
Just another library to find assemblies

## How to use?
Tag your assembly adding the next attribute in your AssemblyInfo.cs file:

    [assembly: AssemblyTag("Tag")]
    
Initiate the finder

    var directory = AppDomain.CurrentDomain.BaseDirectory;
    AssemblyFinder.Current = new AssemblyFinder(directory);
    
Search the assemblies

    var assemblies = AssemblyFinder.Current.GetAssemblies("Tag");
    
[![Build status](https://ci.appveyor.com/api/projects/status/riewcxw29gy77855/branch/master?svg=true)](https://ci.appveyor.com/project/raulnq/jal-assemblyfinder/branch/master)
[![NuGet](https://img.shields.io/nuget/dt/Jal.AssemblyFinder.svg)](https://www.nuget.org/packages/Jal.AssemblyFinder) 
[![NuGet](https://img.shields.io/nuget/vpre/Jal.AssemblyFinder.svg)](https://www.nuget.org/packages/Jal.AssemblyFinder)





