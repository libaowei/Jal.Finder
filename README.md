# Jal.AssemblyFinder
Just another library to find assembies

## How to use?
1. Tag your assembly adding the next attribute in your AssemblyInfo.cs file:

    [assembly: AutoRegisterAssembly("Tag")]
    
2. Initiate the finder

    var directory = AppDomain.CurrentDomain.BaseDirectory;
    AssemblyFinder.Current = new AssemblyFinder(directory);
    
3. Search the assemblies

    var assemblies = AssemblyFinder.Current.GetAssemblies("Tag");





