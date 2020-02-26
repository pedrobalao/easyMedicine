using System;
using System.Collections.Generic;

namespace easyMedicine.Models
{
    public class AuthUser
    {
        public string Uid
        {
            get;
            set;
        }
        public string DisplayName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

        public string PhotoUrl
        {
            get;
            set;
        }
        public string ProviderId
        {
            get;
            set;
        }
        public string RefreshToken
        {
            get;
            set;
        }
    }

    public class AuthToken
    {
        public AuthToken()
        {
            Claims = new Dictionary<string, string>();
        }
        public string Token
        {
            get;
            set;
        }

        public DateTime ExpirationDate
        {
            get;
            set;
        }

        public Dictionary<string, string> Claims
        {
            get; set;
        }
    }

    public class AuthResult
    {
        public AuthResult()
        {
            User = new AuthUser();
            TokenData = new AuthToken();
        }

        public bool AuthSuccessful
        {
            get;
            set;
        }

        public string Error
        {
            get;
            set;
        }

        public AuthUser User
        {
            get;
            set;
        }

        public AuthToken TokenData
        {
            get;
            set;
        }

    }
}
