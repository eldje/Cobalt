using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Cobalt.Modules.MainModule.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand LoginCommand { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoginIsRunning { get; set; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        public LoginViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
