using System;
using easyMedicine.Helpers;

namespace easyMedicine.Models
{
    public static class Configurations
    {
        public const int APP_VERSION = 195;
        public const int INITIAL_DB_VERSION = 16;

        public const string DB_NAME_PREFIX = "easyPedDBV";
        public const string DB_NAME_SUFIX = ".db3";

        public static string GetDBFileName()
        {
            var dbName = DB_NAME_PREFIX + Settings.DBVersionSetting.ToString() + DB_NAME_SUFIX;
            return dbName;
        }
    }
}
