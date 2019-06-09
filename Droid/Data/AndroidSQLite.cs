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

            var sqliteFilename = Configurations.GetDBFileName(out bool initialDb);

            string path;
            if (initialDb)
            {

                //var sqliteFilename = Configurations.DBFILE_NAME;
                //string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder

                path = FileAccessHelper.GetLocalFilePath(sqliteFilename);

            }
            else
            {
                path = sqliteFilename;
            }

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);




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

