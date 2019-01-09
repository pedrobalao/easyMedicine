using System;
using easyMedicine.Services;
using System.IO;
using Xamarin.Forms;
using SQLite;
using easyMedicine.Models;
using Android.App;
using Plugin.DeviceInfo;

namespace easyMedicine.Droid.Data
{
    public class AndroidSQLite : Services.ISQLite
    {

        #region ISQLite implementation




        //    // Return the database connection 
        //    return conn;
        //}

        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = Configurations.DBFILE_NAME;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder

            var path = FileAccessHelper.GetLocalFilePath(sqliteFilename);
            //var path = Path.Combine(documentsPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            //Console.WriteLine(path);
            //if (!File.Exists(path))
            //{
            //    var s = Forms.Context.Resources.OpenRawResource(Resource.Raw.TodoSQLite);  // RESOURCE NAME ###

            //    // create a write stream
            //    FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            //    // write to the stream
            //    ReadWriteStream(s, writeStream);
            //}

            //var param = new SQLiteConnectionString(path, false);

            //ISQLitePlatform plat;
            //if (CrossDeviceInfo.Current.VersionNumber.Major < 7)
            //    plat = new SQLitePlatformAndroid();
            //else
            //plat = new SQLitePlatformAndroidN();

            var connection = new SQLiteAsyncConnection(path);

            // Return the database connection 
            return connection;

        }

        #endregion

        ///// <summary>
        ///// helper method to get the database out of /raw/ and into the user filesystem
        ///// </summary>
        //void ReadWriteStream(Stream readStream, Stream writeStream)
        //{
        //    int Length = 256;
        //    Byte[] buffer = new Byte[Length];
        //    int bytesRead = readStream.Read(buffer, 0, Length);
        //    // write the required bytes
        //    while (bytesRead > 0)
        //    {
        //        writeStream.Write(buffer, 0, bytesRead);
        //        bytesRead = readStream.Read(buffer, 0, Length);
        //    }
        //    readStream.Close();
        //    writeStream.Close();
        //}
    }
}

