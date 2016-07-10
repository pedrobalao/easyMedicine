using System;
using easyMedicine.Services;
using System.IO;
using Xamarin.Forms;

namespace easyMedicine.Droid.Data
{
	public class AndroidSQLite : ISQLite
	{
		#region ISQLite implementation

		public SQLite.Net.SQLiteConnection GetConnection (string dbName)
		{
			var sqliteFilename = dbName + ".db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine (documentsPath, sqliteFilename);

			// This is where we copy in the prepopulated database
			Console.WriteLine (path);
			if (!File.Exists (path)) {
				var s = Forms.Context.Resources.OpenRawResource (Resource.Raw.TodoSQLite);  // RESOURCE NAME ###

				// create a write stream
				FileStream writeStream = new FileStream (path, FileMode.OpenOrCreate, FileAccess.Write);
				// write to the stream
				ReadWriteStream (s, writeStream);
			}

			var conn = new SQLite.Net.SQLiteConnection (path);

			// Return the database connection 
			return conn;
		}

		#endregion

		/// <summary>
		/// helper method to get the database out of /raw/ and into the user filesystem
		/// </summary>
		void ReadWriteStream (Stream readStream, Stream writeStream)
		{
			int Length = 256;
			Byte[] buffer = new Byte[Length];
			int bytesRead = readStream.Read (buffer, 0, Length);
			// write the required bytes
			while (bytesRead > 0) {
				writeStream.Write (buffer, 0, bytesRead);
				bytesRead = readStream.Read (buffer, 0, Length);
			}
			readStream.Close ();
			writeStream.Close ();
		}
	}
}

