using Cobalt.Infrastructure;
using Cobalt.Modules.ToolBars.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Cobalt.Modules.ToolBars
{
    public class ToolBarsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ToolBarsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion, typeof(StatusToolBarView));
            _regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, typeof(MenuToolBarView));
        }
    }
}