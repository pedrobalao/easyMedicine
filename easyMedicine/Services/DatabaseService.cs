using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class DatabaseService : IDatabaseService
    {
        string apiBaseUrl = "https://easypedapi.azurewebsites.net/api/v1";

        public DatabaseService(IDrugsDataService drugsDataService)
        {
            _drugsDataService = drugsDataService;
        }

        private IDrugsDataService _drugsDataService;

        public async Task<AppDb> GetLastestDBVersion(string appVersion)
        {
            return await ApiClient.Instance.Get<AppDb>(apiBaseUrl + "/appdb/latest?appversion=" + appVersion);
        }

        public async Task<int> GetLatesDB()
        {
            var latestVersion = await GetLastestDBVersion(Configurations.APP_VERSION.ToString());
            Settings.GetDB(out int DBVersion, out string DBFile, out bool initialDB);
            if (latestVersion.id > DBVersion)
            {
                var data = "{\"id\": " + latestVersion.id.ToString() + ", \"app\": \"easyPed\", \"date\": " + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + "}";
                var enc = Encryption.Encrypt(data);

                var url = apiBaseUrl + $"/appdb/{latestVersion.id.ToString()}?token={enc.Cypher}&iv={enc.IV}";
                var newDB = await ApiClient.Instance.Get<DbData>(url);


                if (string.IsNullOrWhiteSpace(newDB.url))
                    throw new Exception("Empty DB URL");

                var fileba = await Downloader.DownloadFileAsync(newDB.url);

                var zippedDBFilePath = Path.Combine(FileSystem.AppDataDirectory, newDB.name);
                if (File.Exists(zippedDBFilePath))
                {
                    File.Delete(zippedDBFilePath);
                }
                File.WriteAllBytes(zippedDBFilePath, fileba);

                var filedb = UnzipFile(zippedDBFilePath);

                if (File.Exists(Path.Combine(FileSystem.AppDataDirectory, filedb)))
                {
                    Console.WriteLine();
                    Settings.SetDB(latestVersion.id, filedb);
                    _drugsDataService.Reconnect();
                    Debug.WriteLine("DB updated!");
                }
                return latestVersion.id;
            }

            return -1;

        }

        private string UnzipFile(string zippedDBFilePath)
        {
            var zipArch = ZipFile.Open(zippedDBFilePath, ZipArchiveMode.Read);
            var fileName = zipArch.Entries.First().Name;

            if (!File.Exists(Path.Combine(FileSystem.AppDataDirectory, fileName)))
            {
                ZipFile.ExtractToDirectory(zippedDBFilePath, FileSystem.AppDataDirectory);
            }

            return fileName;
            //return Path.Combine(FileSystem.AppDataDirectory, fileName);
        }






    }
}
