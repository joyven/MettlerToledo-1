using DarkeCarWash.Core;
using DarkeCarWash.MainPage.ApplicationServices;
using DarkeCarWash.MainPage.Views;
using DarkeCarWash.MainPageDomain;
using DarkeCarWash.MainPageDomain.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DarkeCarWash.MainPage
{
    public class MainPageModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MainPageModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //_regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(MainPageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPageView>();
            containerRegistry.Register<ICarWashApplicationService, CarWashApplicationService>();
            containerRegistry.Register<ICarWashDomainServices, CarWashDomainServices>();
        }
        
    }
}