
//using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using Xamarin;

namespace easyMedicine.Core.Services
{
    class CallerService
    {
        public static async Task<bool> Call(Func<Task<bool>> func, string operation)
        {
            bool ret = false;
            //using (UserDialogs.Instance.Loading ("Loading")) {
            try
            {
                ret = await func.Invoke();

            }
            catch (Exception e)
            {
                Crashes.TrackError(e, new Dictionary<string, string> {
                        { "Call ", operation }
                    });
            }

            return ret;
            //}
        }
    }
}
