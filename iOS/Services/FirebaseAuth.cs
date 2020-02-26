using System;
using System.Threading.Tasks;
using easyMedicine.Models;
using Firebase.Auth;
using Foundation;
using easyMedicine.iOS.Helpers;
using easyMedicine.Services;

namespace easyMedicine.iOS.Services
{
    public class IOSFirebaseAuth : IFirebaseAuth
    {

        public bool Logout()
        {
            return Auth.DefaultInstance.SignOut(out _);
        }

        public async Task<AuthToken> RefreshToken()
        {
            var idTokenResult = await Auth.DefaultInstance.CurrentUser.GetIdTokenResultAsync();

            return new AuthToken
            {
                //@TODO add claims
                Token = idTokenResult.Token,
                ExpirationDate = idTokenResult.ExpirationDate.ToDateTime()
            };
        }


        private async Task<AuthResult> LoginFirebase(AuthCredential credential)
        {
            try
            {
                var result = await Auth.DefaultInstance.SignInWithCredentialAsync(credential);
                var idTokenResult = await result.User.GetIdTokenResultAsync();

                var authResult = new AuthResult
                {
                    AuthSuccessful = true,
                    User = new AuthUser
                    {
                        DisplayName = result.User.DisplayName,
                        Email = result.User.Email,
                        PhotoUrl = result.User.PhotoUrl.AbsoluteString,
                        ProviderId = result.User.ProviderId,
                        RefreshToken = result.User.RefreshToken,
                        Uid = result.User.Uid
                    },
                    TokenData = new AuthToken
                    {
                        //@TODO add claims
                        Token = idTokenResult.Token,
                        ExpirationDate = idTokenResult.ExpirationDate.ToDateTime()
                    }
                };

                return authResult;
            }
            catch (Exception e1)
            {
                return new AuthResult
                {
                    AuthSuccessful = false,
                    Error = e1.Message
                };
            }
        }
        public async Task<AuthResult> LoginGoogle(string idToken, string accessToken)
        {
            var credential = GoogleAuthProvider.GetCredential(idToken, accessToken);
            return await LoginFirebase(credential);
        }
        public async Task<AuthResult> LoginFacebook(string accessToken)
        {

            var credential = FacebookAuthProvider.GetCredential(accessToken);
            return await LoginFirebase(credential);
        }


    }
}
