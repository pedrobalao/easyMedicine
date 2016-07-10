using System;
using SQLite.Net;
using SQLite.Net.Async;

namespace easyMedicine.Services
{
	
	public interface ISQLite
	{
		SQLiteAsyncConnection GetConnection ();
	}

}

