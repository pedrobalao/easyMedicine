using System;
using System.Threading.Tasks;

namespace easyMedicine.Services
{
    public interface IDatabaseService
    {
        Task<int> GetLatesDB();
        Task<AppDb> GetLastestDBVersion(string appVersion);
    }
}
