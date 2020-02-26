using System;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Services;
using Xamarin.Forms;

namespace easyMedicine.ViewModels
{
    public class ProfilePageModel : PageModelBase
    {
        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;
        IFirebaseAuth _firebaseServ;

        public ProfilePageModel(INavigatorService navigator, IDrugsDataService drugsDataServ, IFirebaseAuth firebaseServ)
        {
            _drugsDataServ = drugsDataServ;
            _navigator = navigator;
            _firebaseServ = firebaseServ;
            LogoutCommand = new Command(async () => await Logout());

        }



        private string _DisplayName;

        public string DisplayName
        {
            get
            {
                return AuthenticationService.User.DisplayName;
            }
        }

        public const string DisplayNamePropertyName = "DisplayName";

        private string _PhotoUrl;

        public string PhotoUrl
        {
            get
            {
                return AuthenticationService.User.PhotoUrl;
            }
        }

        public const string PhotoUrlPropertyName = "PhotoUrl";

        public ICommand LogoutCommand { get; private set; }

        public const string LogoutCommandPropertyName = "LogoutCommand";

        private async Task Logout()
        {
            AuthenticationService.Logout();
            _firebaseServ.Logout();
            await _navigator.ReplaceRoot<LoginPageModel>("login");
        }

    }
}
