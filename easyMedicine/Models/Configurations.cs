using System;
using System.IO;
using easyMedicine.Helpers;
using Xamarin.Essentials;

namespace easyMedicine.Models
{
    public static class Configurations
    {
        public const int APP_VERSION = 195;
        public const int INITIAL_DB_VERSION = 15;
        public const string INITIAL_DB_FILE = "eMedicineDBV15.sqlite";

        public const string DB_NAME_PREFIX = "easyPedDBV";
        public const string DB_NAME_SUFIX = ".db3";

        public const string API_BASE_URL = "https://easypedapi.azurewebsites.net/api/v1";
        // public const string API_BASE_URL = "http://localhost:3000/api/v1";


        public static string GetDBFileName(out bool initialDB)
        {

            Settings.GetDB(out int DBVersion, out string DBFile, out initialDB);
            //var dbName = Settings.DBFileSetting;
            if (initialDB)
                return DBFile;

            return Path.Combine(FileSystem.AppDataDirectory, DBFile);
        }
    }
}
