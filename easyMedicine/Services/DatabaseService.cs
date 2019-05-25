using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using easyMedicine.Helpers;
using easyMedicine.Models;

namespace easyMedicine.Services
{
    public class DatabaseService
    {
        string apiBaseUrl = "https://easypedapi.azurewebsites.net/api/v1";

        public DatabaseService()
        {
        }

        public async Task<int> GetLastestDBVersion(string appVersion)
        {
            return await ApiClient.Instance.Get<int>(apiBaseUrl + "/appdb/latest?appversion=" + appVersion);
        }

        public async Task GetLatesDB(int currentDBVersion)
        {
            var latestVersion = 17; //await GetLastestDBVersion(Configurations.APP_VERSION.ToString());
            if (latestVersion > currentDBVersion)
            {
                var data = "{\"id\": " + latestVersion + ", \"app\": \"easyPed\", \"date\": " + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + "}";
                var enc = Encryption.Encrypt(data);

                var url = apiBaseUrl + $"/appdb/{latestVersion}?token={enc.Cypher}&iv={enc.IV}";
                await ApiClient.Instance.Get<int>(url);
            }

        }



    }
}
