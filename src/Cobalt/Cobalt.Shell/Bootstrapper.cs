using System.Windows;
using Cobalt.Modules.TabContent;
using Cobalt.Modules.ToolBars;
using Cobalt.Shell.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;

namespace Cobalt.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog) ModuleCatalog;
            catalog.AddModule(typeof(ToolBarsModule));
            catalog.AddModule(typeof(TabContentModule));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => Container.Resolve(type));
        }
    }
}