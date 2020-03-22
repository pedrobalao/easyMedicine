using System;
using System.Threading.Tasks;
using easyMedicine.Models;
using easyMedicine.Services;
using Firebase;
using Firebase.Auth;


namespace easymedicine.Droid.Services
{
    public class AndroidFirebaseAuth : IFirebaseAuth
    {



        public bool Logout()
        {
            Firebase.Auth.FirebaseAuth.Instance.SignOut();
            return true;
            // return Auth.DefaultInstance.SignOut(out _);
        }

        public async Task<AuthToken> RefreshToken()
        {
            var idTokenResult = await FirebaseAuth.Instance.CurrentUser.GetIdTokenAsync(true);

            return new AuthToken
            {
                //@TODO add claims
                Token = idTokenResult.Token,
                ExpirationDate = DateTimeOffset.FromUnixTimeSeconds(idTokenResult.ExpirationTimestamp).UtcDateTime
            };
        }


        private async Task<AuthResult> LoginFirebase(AuthCredential credential)
        {
            try
            {
                var result = await FirebaseAuth.Instance.SignInWithCredentialAsync(credential);
                var idTokenResult = await result.User.GetIdTokenAsync(true);

                var authResult = new AuthResult
                {
                    AuthSuccessful = true,
                    User = new AuthUser
                    {
                        DisplayName = result.User.DisplayName,
                        Email = result.User.Email,
                        PhotoUrl = result.User.PhotoUrl.ToString(),
                        ProviderId = result.User.ProviderId,
                        // RefreshToken = idTokenResult.RefreshToken,
                        Uid = result.User.Uid
                    },
                    TokenData = new AuthToken
                    {
                        //@TODO add claims
                        Token = idTokenResult.Token,
                        ExpirationDate = DateTimeOffset.FromUnixTimeSeconds(idTokenResult.ExpirationTimestamp).UtcDateTime
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
