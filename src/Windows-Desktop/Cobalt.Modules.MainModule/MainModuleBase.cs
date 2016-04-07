using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobalt.DataAccess.Repositories;
using Cobalt.Modules.MainModule.Services;
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
            _container.RegisterType<ILoginService, LoginService>();
            _container.RegisterType<IAccountRepository, AccountRepository>();

            _regionManager.RegisterViewWithRegion("DataRegion", typeof(LoginView));
        }
    }
}
