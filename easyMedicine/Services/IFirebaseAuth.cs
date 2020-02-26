using System;
using System.Threading.Tasks;
using easyMedicine.Models;

namespace easyMedicine.Services
{
    public interface IFirebaseAuth
    {
        bool Logout();
        Task<AuthResult> LoginGoogle(string idToken, string accessToken);
        Task<AuthResult> LoginFacebook(string accessToken);
        Task<AuthToken> RefreshToken();
    }
}
