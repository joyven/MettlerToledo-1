using DarkeCarWash.Core;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DarkeCarWash.LeftMenu
{
    public class LeftMenuModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public LeftMenuModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.LeftRegion, typeof());
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}