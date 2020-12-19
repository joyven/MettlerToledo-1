using Prism.Mvvm;

namespace DarkeCarWash.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Darke's Car Wash";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
