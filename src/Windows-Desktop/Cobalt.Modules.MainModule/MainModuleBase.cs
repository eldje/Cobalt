using Cobalt.Infrastructure;
using Cobalt.Modules.MainModule.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Cobalt.Modules.MainModule
{
    public class MainModuleBase : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public MainModuleBase(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<object, DataGridView>("DataGridView");

            _regionManager.RegisterViewWithRegion(RegionNames.DataRegion, typeof(LoginView));
        }
    }
}
