# Modules

A module is a logical collection of functionality and resources that is packaged in a way that can be separately developed, tested, deployed, and integrated into an application. Each module has a central class that is responsible for initializing the module and integrating its functionality into the application. That class implements the IModule interface. In most cases the naming convention of the class is *[ModuleName]Module*, and can be found in the root namespace of the project.

The IModule interface has a single method, named Initialize, within which you can implement whatever logic is required to initialize and integrate the module's functionality into the application. Depending on the purpose of the module, it can register views into composite user interfaces, make additional services available to the application, or extend the application's functionality. 

In order for modules to be initialized they must be configured in the Bootstrapper, for more information see [Bootstrapper](https://github.com/TravisBoatman/Cobalt/blob/master/docs/Bootstrapper.md)

Take for example the ToolBarsModule:
```csharp
    public class ToolBarsModule : IModule
    {
        private readonly IRegionManager _regionManager;
        
        // Using dependency injection.
        public RibbonModuleBase(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        // Add the module view to the region manager on load.
        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion, typeof(StatusToolBarView));
        }
    }
````

For more information see [Modular Application Development](https://msdn.microsoft.com/en-us/library/gg405479(v=pandp.40).aspx)
