using Cobalt.DataAccess.Context;
using Cobalt.Infrastructure;
using Cobalt.Modules.TabContent.Services;
using Cobalt.Modules.TabContent.Services.Interfaces;
using Cobalt.Modules.TabContent.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Cobalt.Modules.TabContent
{
    public class TabContentModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public TabContentModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _unityContainer.RegisterType(typeof(object), typeof(ComplaintResultsView), "ComplaintGridView");
            _unityContainer.RegisterType(typeof(object), typeof(ContactResultsView), "ContactResultsView");

            _unityContainer.RegisterType<ICobaltContext, CobaltContext>(new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<IComplaintService, ComplaintService>();
            _unityContainer.RegisterType<IExpressionBuilder, ExpressionBuilder>(new TransientLifetimeManager());

            _regionManager.RegisterViewWithRegion(RegionNames.ComplaintRegion, typeof(ComplaintSearchView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContactRegion, typeof(ContactSearchView));
            _regionManager.RegisterViewWithRegion(RegionNames.ImportExportRegion, typeof(ImportExportView));
            _regionManager.RegisterViewWithRegion(RegionNames.FileStorageRegion, typeof(FileStorageView));
        }
    }
}