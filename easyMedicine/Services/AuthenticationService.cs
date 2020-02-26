using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using easyMedicine.Models;
using Microsoft.AppCenter.Analytics;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace easyMedicine.Services
{
    public static class AuthenticationService
    {
        private static ISettings AppSettings => CrossSettings.Current;

        const string USER_KEY = "AUTH_USER";
        const string TOKEN_KEY = "AUTH_TOKEN";

        public static AuthUser User
        {
            get;
            private set;
        }

        public static AuthToken TokenAuth
        {
            get;
            private set;
        }

        public static bool IsUserAuthenticated
        {
            get => User != null;
        }


        public static bool HasTypeSetted
        {
            get;
            set;
        }
        /// <summary>
        /// Load the Authentication Data from the store
        /// </summary>
        /// <returns>true if there is an user authenticated, otherwise false</returns>
        public static bool LoadAuth()
        {
            if (AppSettings.Contains(USER_KEY))
            {
                User = JsonConvert.DeserializeObject<AuthUser>(AppSettings.GetValueOrDefault(USER_KEY, String.Empty));
                TokenAuth = JsonConvert.DeserializeObject<AuthToken>(AppSettings.GetValueOrDefault(TOKEN_KEY, String.Empty));

                return true;
            }

            return false;
        }

        public static async Task Login(AuthResult authResult)
        {
            //save on the settings
            User = authResult.User;
            TokenAuth = authResult.TokenData;

            string userJson = JsonConvert.SerializeObject(User);
            string tokenAuthJson = JsonConvert.SerializeObject(TokenAuth);
            AppSettings.AddOrUpdateValue(USER_KEY, userJson);
            AppSettings.AddOrUpdateValue(TOKEN_KEY, tokenAuthJson);

            HasTypeSetted = await HasUserTypeSetted();

        }

        public static void Logout()
        {
            User = null;
            TokenAuth = null;
            AppSettings.Remove(USER_KEY);
            AppSettings.Remove(TOKEN_KEY);
        }

        public static async Task<string> GetToken()
        {
            if (!IsUserAuthenticated)
                return String.Empty;

            if (TokenAuth.ExpirationDate < DateTime.UtcNow.AddMinutes(-2))
            {
                var firebaseAuth = Bootstrapper.Instance.Resolve<IFirebaseAuth>();
                var authToken = await firebaseAuth.RefreshToken();
                TokenAuth = authToken;
            }

            return TokenAuth.Token;

        }

        public static async Task<bool> HasUserTypeSetted()
        {
            try
            {
                var response = await ApiClient.Instance.Get<LoginResponse>(Configurations.API_BASE_URL + "/auth/login");
                return response.has_type;
            }
            catch (Exception e1)
            {
                Analytics.TrackEvent("Error", new Dictionary<string, string> {
                    { "Local", "AuthenticationService.HasUserTypeSetted"},
                    { "Message", e1.Message},
                    { "StackTrace", e1.StackTrace}
                });
                return true;
            }
        }

        public static async Task<bool> SetUserType(SetUserTypeRequest data)
        {
            try
            {
                await ApiClient.Instance.Post<SetUserTypeRequest>(Configurations.API_BASE_URL + "/auth/usertype", data);
                return true;
            }
            catch (Exception e1)
            {
                Analytics.TrackEvent("Error", new Dictionary<string, string> {
                { "Local", "AuthenticationService.SetUserType"},
                { "Message", e1.Message},
                { "StackTrace", e1.StackTrace}
            });
                return false;
            }
        }
    }

    public class SetUserTypeRequest
    {
        public string type
        {
            get;
            set;
        }

        public string professional_id
        {
            get;
            set;
        }
    }

    public class LoginResponse
    {
        public bool has_type
        {
            get;
            set;
        }
    }
}
