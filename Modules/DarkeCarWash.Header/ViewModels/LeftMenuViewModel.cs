using DarkeCarWash.Core;
using DarkeCarWash.Core.Enums;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkeCarWash.Header.ViewModels
{
    public class LeftMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> CarWashCommand { get; set; }

        public LeftMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CarWashCommand = new DelegateCommand<string>(CarWash);
        }

        private void CarWash(string parameter)
        {
            var navParam = new NavigationParameters();
            switch (parameter)
            {
                case "Express":
                    navParam.Add("Mode", WashMode.Express);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, "MainPageView", navParam);
                    break;
                case "BestValue":
                    navParam = new NavigationParameters();
                    navParam.Add("Mode", WashMode.BestValue);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, "MainPageView", navParam);
                    break;
                case "Signature":
                    navParam = new NavigationParameters();
                    navParam.Add("Mode", WashMode.Signature);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, "MainPageView", navParam);
                    break;
            }
        }
    }
}
