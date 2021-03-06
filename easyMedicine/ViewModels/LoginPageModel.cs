﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using easyMedicine.Core.Models;
using easyMedicine.Core.Services;
using easyMedicine.Helpers;
using easyMedicine.Models;
using easyMedicine.Pages;
using easyMedicine.Services;
using Microsoft.AppCenter.Analytics;
using Xamarin.Auth;
using Xamarin.Forms;

namespace easyMedicine.ViewModels
{
    public class LoginPageModel : PageModelBase
    {
        IDrugsDataService _drugsDataServ;
        INavigatorService _navigator;
        IFirebaseAuth _firebaseServ;
        Xamarin.Auth.OAuth2Authenticator authenticator;


        public LoginPageModel(INavigatorService navigator, IDrugsDataService drugsDataServ, IFirebaseAuth firebaseServ)
        {
            GoogleSelectedCommand = new Command(async () => await LoginWithGoogle());
            FacebookSelectedCommand = new Command(async () => await LoginWithFacebook());
            this._drugsDataServ = drugsDataServ;
            this._navigator = navigator;
            this._firebaseServ = firebaseServ;

        }

        public ICommand GoogleSelectedCommand { get; private set; }

        public const string GoogleSelectedCommandPropertyName = "GoogleSelectedCommand";

        public ICommand FacebookSelectedCommand { get; private set; }

        public const string FacebookSelectedCommandPropertyName = "FacebookSelectedCommand";




        public async Task LoginWithGoogle()
        {
            authenticator
                 = new Xamarin.Auth.OAuth2Authenticator
                 (
                     clientId:
                         new Func<string>
                            (
                                () =>
                                {
                                    string retval_client_id = "oops something is wrong!";

                                    // some people are sending the same AppID for google and other providers
                                    // not sure, but google (and others) might check AppID for Native/Installed apps
                                    // Android and iOS against UserAgent in request from 
                                    // CustomTabs and SFSafariViewContorller
                                    // TODO: send deliberately wrong AppID and note behaviour for the future
                                    // fitbit does not care - server side setup is quite liberal
                                    switch (Xamarin.Forms.Device.RuntimePlatform)
                                    {
                                        case "Android":
                                            retval_client_id = Secrets.AndroidGoogleClientId;
                                            break;
                                        case "iOS":
                                            retval_client_id = Secrets.IOSGoogleClientId;
                                            break;
                                    }
                                    return retval_client_id;
                                }
                           ).Invoke(),
                    clientSecret: null,   // null or ""
                    authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"),
                    accessTokenUrl: new Uri("https://www.googleapis.com/oauth2/v4/token"),
                    redirectUrl:
                        new Func<Uri>
                            (
                                () =>
                                {

                                    string uri = null;

                                    // some people are sending the same AppID for google and other providers
                                    // not sure, but google (and others) might check AppID for Native/Installed apps
                                    // Android and iOS against UserAgent in request from 
                                    // CustomTabs and SFSafariViewContorller
                                    // TODO: send deliberately wrong AppID and note behaviour for the future
                                    // fitbit does not care - server side setup is quite liberal
                                    switch (Xamarin.Forms.Device.RuntimePlatform)
                                    {
                                        case "Android":
                                            uri = Secrets.AndroidGoogleRedirect + ":/oauth2redirect";
                                            break;
                                        case "iOS":
                                            uri = Secrets.IOSGoogleRedirect + ":/oauth2redirect";
                                            break;

                                    }

                                    return new Uri(uri);
                                }
                             ).Invoke(),
                     scope:
                          //"profile"
                          "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login"
                          ,
                     getUsernameAsync: null,
                     isUsingNativeUI: Settings.IsUsingNativeUI
                 )
                 {
                     AllowCancel = true,
                 };

            authenticator.Completed +=
                async (s, ea) =>
                {
                    StringBuilder sb = new StringBuilder();

                    if (ea.Account != null && ea.Account.Properties != null)
                    {
                        //sb.Append("Token = ").AppendLine($"{ea.Account.Properties["access_token"]}");
                        //sb.Append("id_token = ").AppendLine($"{ea.Account.Properties["id_token"]}");
                        var authResult = await _firebaseServ.LoginGoogle(ea.Account.Properties["id_token"], ea.Account.Properties["access_token"]);

                        await AuthenticationResult(authResult.AuthSuccessful, "Google", authResult.Error, authResult);
                    }
                    else
                    {
                        sb.Append("Not authenticated ").AppendLine($"Account.Properties does not exist");
                        await AuthenticationResult(false, "Google", sb.ToString());

                    }

                    return;
                };

            authenticator.Error +=
                async (s, ea) =>
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Error = ").AppendLine($"{ea.Message}");


                    await AuthenticationResult(false, "Google", ea.Message);

                    return;
                };

            await OpenAuthenticationPage(authenticator);

            return;
        }

        internal async Task SkipAuthentication()
        {
            await _navigator.ReplaceRoot<NewRootPageModel>("Root", (Model) =>
            {
                Model.CollectUserInfo = !AuthenticationService.HasTypeSetted;
            });
        }

        protected async Task LoginWithFacebook()
        {
            authenticator
                 = new Xamarin.Auth.OAuth2Authenticator
                 (
                     clientId:
                         new Func<string>
                            (
                                () =>
                                {
                                    string retval_client_id = "oops something is wrong!";

                                    retval_client_id = Secrets.FacebookAppId;
                                    return retval_client_id;
                                }
                            ).Invoke(),
                     //clientSecret: null,   // null or ""
                     authorizeUrl: new Uri("https://www.facebook.com/v2.9/dialog/oauth"),
                     redirectUrl: new Uri($"fb{Secrets.FacebookAppId}://authorize"),
                     scope: "email",
                     getUsernameAsync: null,
                     isUsingNativeUI: Settings.IsUsingNativeUI
                 )
                 {
                     AllowCancel = true,
                 };

            authenticator.Completed +=
                async (s, ea) =>
                {
                    StringBuilder sb = new StringBuilder();

                    if (ea.Account != null && ea.Account.Properties != null)
                    {
                        sb.Append("Token = ").AppendLine($"{ea.Account.Properties["access_token"]}");
                        var authResult = await _firebaseServ.LoginFacebook(ea.Account.Properties["access_token"]);

                        await AuthenticationResult(authResult.AuthSuccessful, "Facebook", authResult.Error, authResult);
                    }
                    else
                    {
                        sb.Append("Not authenticated ").AppendLine($"Account.Properties does not exist");
                        await AuthenticationResult(false, "Facebook", sb.ToString());
                    }

                    return;
                };

            authenticator.Error +=
                async (s, ea) =>
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Error = ").AppendLine($"{ea.Message}");

                    await AuthenticationResult(false, "Facebook", sb.ToString());
                    return;
                };

            await OpenAuthenticationPage(authenticator);

            return;
        }

        public async Task OpenAuthenticationPage(OAuth2Authenticator authenticator)
        {

            // after initialization (creation and event subscribing) exposing local object 
            AuthenticationState.Authenticator = authenticator;

            await _navigator.PushAuthenticatorModal((model) =>
            {
                model.Authenticator = authenticator;
            });

            //await _navigator.PushModalAsync<AuthenticatorPageModel>("AuthenticatorPage", (model) =>
            //{
            //    model.Authenticator = authenticator;
            //});
        }

        public async Task AuthenticationResult(bool success, string provider, string errorMessage, AuthResult authResult = null)
        {
            if (success)
            {
                await AuthenticationService.Login(authResult);
                //pop Authenticator
                //if (Device.RuntimePlatform == Device.Android)
                //{
                await _navigator.PopModalAsync();
                //}
                //await _navigator.PopModalAsync();
                //pop Login Page
                await _navigator.ReplaceRoot<NewRootPageModel>("Root", (Model) =>
            {
                Model.CollectUserInfo = !AuthenticationService.HasTypeSetted;
            });
                Analytics.TrackEvent("Authentication Success", new Dictionary<string, string> {
                        { "Provider", provider },
                        { "User", authResult.User.Uid }
                    });

            }
            else
            {
                await _navigator.PopModalAsync();
                MessagingCenter.Send<LoginPageModel, string>(this, "AuthenticationError", "Autenticação falhou!");

                Analytics.TrackEvent("Authentication Error", new Dictionary<string, string> {
                        { "Provider", provider},
                        { "Error", errorMessage}
                    });
            }
        }
    }
}