using DarkeCarWash.Core.Enums;
using DarkeCarWash.MainPage.ApplicationServices;
using DarkeCarWash.MainPage.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DarkeCarWash.MainPage.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        WashMode mode;
        private bool _isPreSoak;

        public bool IsPreSoak
        {
            get { return _isPreSoak; }
            set
            {
                _isPreSoak = value;
                if (_isPreSoak) AddCost(1);
                else AddCost(-1);
                OnPropertyChanged(new PropertyChangedEventArgs("IsPreSoak"));
            }
        }
        private bool _isSoftWater;

        public bool IsSoftWater
        {
            get { return _isSoftWater; }
            set
            {
                _isSoftWater = value;
                if (_isSoftWater) AddCost(1);
                else AddCost(-1);
                OnPropertyChanged(new PropertyChangedEventArgs("IsSoftWater"));
            }
        }
        private bool _isDryAgent;

        public bool IsDryAgent
        {
            get { return _isDryAgent; }
            set
            {
                _isDryAgent = value;
                if (_isDryAgent) AddCost(1);
                else AddCost(-1);
                OnPropertyChanged(new PropertyChangedEventArgs("IsDryAgent"));
            }
        }

        private bool _isTyreShine;

        public bool IsTyreShine
        {
            get { return _isTyreShine; }
            set
            {
                _isTyreShine = value;
                if (_isTyreShine) AddCost(1);
                else AddCost(-1);
                OnPropertyChanged(new PropertyChangedEventArgs("IsTyreShine"));
            }
        }

        private bool _isRainShield;

        public bool IsRainShield
        {
            get { return _isRainShield; }
            set
            {
                _isRainShield = value;
                if (_isRainShield) AddCost(1);
                else AddCost(-1);
                OnPropertyChanged(new PropertyChangedEventArgs("IsRainShield"));
            }
        }

        private int totCost;

        public int TotalCost
        {
            get { return totCost; }
            set { totCost = value; OnPropertyChanged(new PropertyChangedEventArgs("TotalCost")); }
        }

        private bool _isCostValue;
        public bool IsCostValue
        {
            get { return _isCostValue; }
            set { _isCostValue = value; OnPropertyChanged(new PropertyChangedEventArgs("IsCostValue")); }
        }

        private bool _isSignature;
        public bool IsSignature
        {
            get { return _isSignature; }
            set { _isSignature = value; OnPropertyChanged(new PropertyChangedEventArgs("IsSignature")); }
        }

        private string selectedMode;
        private readonly ICarWashApplicationService _applicationService;

        public string SelectedMode
        {
            get { return selectedMode; }
            set { selectedMode = value; OnPropertyChanged(new PropertyChangedEventArgs("SelectedMode")); }
        }

        public DelegateCommand<string> CreateJobCommand { get; set; }

        public MainPageViewModel(ICarWashApplicationService applicationService)
        {
            CreateJobCommand = new DelegateCommand<string>(CreateJob);
            _applicationService = applicationService;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {

            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            mode = navigationContext.Parameters.GetValue<WashMode>("Mode");
            ChangeSelection(mode);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
        }

        private void AddCost(int cost)
        {
            TotalCost += cost;
        }
        private void ChangeSelection(WashMode mode)
        {
            RestValues();
            switch (mode)
            {
                case WashMode.Express:
                    SelectedMode = $"Express Mode";
                    IsCostValue = false;
                    IsSignature = false;
                    TotalCost = 0;
                    break;
                case WashMode.BestValue:
                    SelectedMode = $"Best Value Mode";
                    IsSignature = false;
                    IsCostValue = true;
                    TotalCost = 2;
                    break;
                case WashMode.Signature:
                    SelectedMode = $"{WashMode.Signature} Mode";
                    IsSignature = true;
                    IsCostValue = true;
                    TotalCost = 4;
                    break;
            }
        }
        private void RestValues()
        {
            IsPreSoak = false;
            IsSoftWater = false;
            IsDryAgent = false;
            IsTyreShine = false;
            IsRainShield = false;
            TotalCost = 0;
        }

        private void CreateJob(string isCreate)
        {
            if (isCreate == "True")
            {
                CarWashClientModel model = new CarWashClientModel()
                {
                    IsPreSoak = IsPreSoak,
                    IsSoftWater = IsSoftWater,
                    IsDryAgent = IsDryAgent,
                    IsTyreShine = IsTyreShine,
                    IsRainShield = IsRainShield,
                    WashMode = mode,
                    TotCost = TotalCost,
                };
                if (_applicationService.CreateJob(model))
                {
                    MessageBox.Show("Your car wash job created successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Your car wash job hasn't created try again..", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                var result = MessageBox.Show("Are you sure want to cancel!", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (MessageBoxResult.Yes == result)
                {
                    RestValues();
                }
            }
        }

    }
}
