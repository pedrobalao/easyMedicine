using System;
using SQLite;

namespace easyMedicine.Services
{

    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }

}

