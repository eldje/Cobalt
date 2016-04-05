using Cobalt.Modules.Ribbon.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Cobalt.Modules.Ribbon
{
    public class RibbonModuleBase : IModule
    {
        private readonly IRegionManager _regionManager;

        public RibbonModuleBase(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.AddToRegion("RibbonRegion", new RibbonView());
        }
    }
}
