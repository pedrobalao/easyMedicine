using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using easyMedicineAPI.DataModel;
using System.Text;

namespace easyMedicineAPI.Controllers
{
    [Route("api/[controller]")]
    public class DBVersionController : Controller
    {
        // GET api/DBVersion/1
        [HttpGet("{appVersion}")]
        public int Get(int appVersion)
        {
            try
            {
                using (var db = new EasyMedicineContext())
                {
                    var version = db.DBVersion.FirstOrDefault(x=> x.AppVersion == appVersion);

                    if(version == default(DBVersion))
                        throw new ArgumentException("Invalid appVersion");
                    
                    return version.DataVersion;
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }

    }
}
