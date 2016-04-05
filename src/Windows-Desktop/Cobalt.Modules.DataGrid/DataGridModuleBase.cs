using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobalt.Modules.DataGrid.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Cobalt.Modules.DataGrid
{
    public class DataGridModuleBase : IModule
    {
        private readonly IRegionManager _regionManager;

        public DataGridModuleBase(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.AddToRegion("DataRegion", new DataGridView());
        }
    }
}
