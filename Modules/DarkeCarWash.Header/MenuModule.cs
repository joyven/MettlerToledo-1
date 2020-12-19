using DarkeCarWash.Core;
using DarkeCarWash.Header.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace DarkeCarWash.Header
{
    public class MenuModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MenuModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        private void Execu()
        {
            throw new NotImplementedException();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.HeaderRegion, typeof(HeaderView));
            _regionManager.RegisterViewWithRegion(RegionNames.LeftRegion, typeof(LeftMenu));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}