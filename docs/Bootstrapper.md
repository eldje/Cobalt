# Bootstrapper

A bootstrapper is a class that is responsible for the initialization of an application built using the Prism Library. By using a bootstrapper, you have more control of how the Prism Library components are wired up to your application.

In a traditional Windows Presentation Foundation (WPF) application, a startup Uniform Resource Identifier (URI) is specified in the App.xaml file that launches the main window. 
In an application created with the Prism Library, it is the bootstrapper's responsibility to create the shell or the main window. This is because the shell relies on services, such as the Region Manager, that need to be registered before the shell can be displayed.

The Prism Library includes the UnityBootstrapper and MefBootstrapper classes, which implement most of the functionality necessary to use either Unity or MEF as the dependency injection container in your application.
Cobalt uses the UnityBootstrapper.

The Bootstrapper provides a protected ModuleCatalog property to reference the catalog as well as a base implementation of the virtual CreateModuleCatalog method. 
In order for modules to be initialized they must be configured in the Bootstrapper.

Take for example the Bootstrapper from the Cobalt Project:
```csharp
public class Bootstrapper : UnityBootstrapper
    {
        // Create the MainWindow Shell
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        // Configure any modules
        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog) ModuleCatalog;
            catalog.AddModule(typeof (RibbonModuleBase));
            catalog.AddModule(typeof (MainModuleBase));
        }

        // Additional Configuration
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => Container.Resolve(type));
        }
    }
```

To learn more see [Initializing Applications](https://msdn.microsoft.com/en-us/library/gg430868(v=pandp.40).aspx)
