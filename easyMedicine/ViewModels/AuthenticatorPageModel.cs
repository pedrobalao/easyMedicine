using System;
using easyMedicine.Core.Models;

namespace easyMedicine.ViewModels
{
    public class AuthenticatorPageModel : PageModelBase
    {
        private Xamarin.Auth.OAuth2Authenticator _Authenticator;

        public Xamarin.Auth.OAuth2Authenticator Authenticator
        {
            get
            {
                return _Authenticator;
            }
            set
            {
                _Authenticator = value;
                OnPropertyChanged(AuthenticatorPropertyName);
            }
        }

        public const string AuthenticatorPropertyName = "Authenticator";


    }
}
