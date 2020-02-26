using System;
using easyMedicine.ViewModels;

namespace easyMedicine.Pages
{
    public class AuthenticatorPage : Xamarin.Auth.XamarinForms.AuthenticatorPage
    {
        private AuthenticatorPageModel Model
        {
            get;
            set;
        }

        public AuthenticatorPage(AuthenticatorPageModel model) : base(model.Authenticator)
        {
            this.Model = model;
        }
    }
}
