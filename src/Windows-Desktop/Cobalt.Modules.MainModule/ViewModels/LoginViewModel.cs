using System;
using System.Linq;
using Cobalt.Modules.MainModule.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Cobalt.Modules.MainModule.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegionManager _regionManager;

        public string Username { get; set; }
        public string Password { get; set; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        public DelegateCommand LoginCommand { get; set; }

        public LoginViewModel(ILoginService loginService, IRegionManager regionManager)
        {
            _loginService = loginService;
            _regionManager = regionManager;
            LoginCommand = new DelegateCommand(Login);
        }

        public void Login()
        {
            var view = _regionManager.Regions["DataRegion"].ActiveViews.FirstOrDefault();
            _regionManager.Regions["DataRegion"].Remove(view);

            _regionManager.RequestNavigate("DataRegion", new Uri("DataGridView", UriKind.Relative));

            //var account = _loginService.GetAccount(Username);

            //if (account == null)
            //{
            //    ErrorMessage = "Incorrect username!";
            //    return;
            //}

            //if (_loginService.Login(account, Password))
            //{
            //    var view = _regionManager.Regions["DataRegion"].ActiveViews.FirstOrDefault();
            //    _regionManager.Regions["DataRegion"].Remove(view);

            //    _regionManager.RequestNavigate("DataRegion", "DataGridView");
            //}
            //else
            //{
            //    ErrorMessage = "Password is incorrect!";
            //}
        }
    }
}
