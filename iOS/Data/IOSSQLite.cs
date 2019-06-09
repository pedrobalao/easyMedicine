using System;
using easyMedicine.Services;
using System.IO;
using Foundation;
using easyMedicine.Models;
using SQLite;

namespace easyMedicine.iOS.Data
{
    public class IOSSQLite : ISQLite
    {
        public IOSSQLite()
        {
        }

        #region ISQLite implementation



        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = Configurations.GetDBFileName(out bool initialDb);

            string path;
            if (initialDb)
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                path = Path.Combine(libraryPath, sqliteFilename);
            }
            else
            {
                path = sqliteFilename;
            }

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                var appdir = NSBundle.MainBundle.ResourcePath;
                var seedFile = Path.Combine(appdir, sqliteFilename);

                File.Copy(seedFile, path);
            }

            //var conn = new SQLite.Net.SQLiteConnection (path);

            //var param = new SQLiteConnectionString(path, false);
            var connection = new SQLiteAsyncConnection(path);

            // Return the database connection 
            return connection;
        }

        #endregion
    }
}

