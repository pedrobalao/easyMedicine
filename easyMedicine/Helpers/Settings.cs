using System;
using System.Collections.Generic;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Linq;
using System.Text;
using easyMedicine.Models;

namespace easyMedicine.Helpers
{

    public static class Settings
    {
        private const string FavouriteSettingsKey = "Favourites";
        private static readonly string FavouriteSettingsDefault = string.Empty;

        private const string DBVersionSettingsKey = "DBVersion";
        private const string DBFileSettingsKey = "DBFile";

        private static ISettings AppSettings => CrossSettings.Current;

        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(nameof(GeneralSettings), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value);

        }

        public static void AddFavourite(string idDrug)
        {
            var favs = FavouriteSettings;
            if (!favs.Contains(idDrug))
            {
                favs.Add(idDrug);
                FavouriteSettings = favs;
            }
        }


        public static void RemoveFavourite(string idDrug)
        {
            var favs = FavouriteSettings;
            if (favs.Contains(idDrug))
            {
                favs.Remove(idDrug);
                FavouriteSettings = favs;
            }
        }


        public static List<string> FavouriteSettings
        {
            get
            {
                var setts = AppSettings.GetValueOrDefault(FavouriteSettingsKey, FavouriteSettingsDefault);
                if (string.IsNullOrEmpty(setts))
                    return new List<string>();

                return setts.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            }
            set
            {
                var str = new StringBuilder();
                value.All(x =>
                {
                    str.AppendFormat(",{0}", x);
                    return true;
                });
                AppSettings.AddOrUpdateValue(FavouriteSettingsKey, str.ToString());
            }
        }

        public static bool IsFavourite(string drugId)
        {
            return FavouriteSettings.Contains(drugId);
        }

        private static string DBFileSetting
        {
            get
            {
                var dbv = AppSettings.GetValueOrDefault(DBFileSettingsKey, Configurations.INITIAL_DB_FILE);
                return dbv;
            }
            set
            {
                AppSettings.AddOrUpdateValue(DBFileSettingsKey, value);
            }
        }


        private static int DBVersionSetting
        {
            get
            {
                var dbv = AppSettings.GetValueOrDefault(DBVersionSettingsKey, Configurations.INITIAL_DB_VERSION);
                return dbv;
            }
            set
            {
                AppSettings.AddOrUpdateValue(DBVersionSettingsKey, value);
            }
        }

        public static void GetDB(out int dbVersion, out string dbFile, out bool initialDB)
        {
            dbVersion = DBVersionSetting;
            if (Configurations.INITIAL_DB_VERSION > dbVersion)
            {
                SetDB(Configurations.INITIAL_DB_VERSION, Configurations.INITIAL_DB_FILE);
                dbVersion = Configurations.INITIAL_DB_VERSION;
            }
            dbFile = DBFileSetting;

            if (dbVersion == Configurations.INITIAL_DB_VERSION)
            {
                initialDB = true;
            }
            else
            {
                initialDB = false;
            }
        }

        public static void SetDB(int dbVersion, string dbFile)
        {
            DBVersionSetting = dbVersion;
            DBFileSetting = dbFile;
        }


    }
}
