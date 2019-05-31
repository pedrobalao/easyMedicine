using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using easyMedicine.Helpers;
using easyMedicine.Models;
using Xamarin.Essentials;

namespace easyMedicine.Services
{
    public class AppDb
    {
        public int id
        {
            get;
            set;
        }
    }
    public class DbData
    {
        public int id
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string url
        {
            get;
            set;
        }
    }
    public class DatabaseService
    {
        string apiBaseUrl = "https://easypedapi.azurewebsites.net/api/v1";

        public DatabaseService()
        {
        }

        public async Task<AppDb> GetLastestDBVersion(string appVersion)
        {
            return await ApiClient.Instance.Get<AppDb>(apiBaseUrl + "/appdb/latest?appversion=" + appVersion);
        }

        public async Task GetLatesDB(int currentDBVersion)
        {
            var latestVersion = await GetLastestDBVersion(Configurations.APP_VERSION.ToString());
            if (latestVersion.id > currentDBVersion)
            {
                var data = "{\"id\": " + latestVersion.id.ToString() + ", \"app\": \"easyPed\", \"date\": " + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + "}";
                var enc = Encryption.Encrypt(data);

                var url = apiBaseUrl + $"/appdb/{latestVersion.id.ToString()}?token={enc.Cypher}&iv={enc.IV}";
                var newDB = await ApiClient.Instance.Get<DbData>(url);

                Debug.WriteLine("URL - " + newDB.url);
                //await UnzipFile(newDB.base64);

            }
        }

        public async Task UnzipFile(string base64)
        {
            var zippedDB = Convert.FromBase64String(base64);

            var zippedDBFileName = "temp_" + DateTime.Now.Ticks.ToString() + ".zip";
            var zippedDBFilePath = Path.Combine(FileSystem.AppDataDirectory, zippedDBFileName);
            File.WriteAllBytes(zippedDBFilePath, zippedDB);

            ZipFile.ExtractToDirectory(zippedDBFilePath, FileSystem.AppDataDirectory);

            var dbFile = Path.Combine(FileSystem.AppDataDirectory, "easyPedDBV16.db3");

            return;
        }



    }
}
