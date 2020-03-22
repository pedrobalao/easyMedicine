using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using easyMedicine.Models;

namespace easyMedicine.Services
{

    public sealed class DiseaseCache
    {
        private static volatile DiseaseCache instance;
        private static object syncRoot = new object();

        private DiseaseCache() { }

        public static DiseaseCache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DiseaseCache();
                    }
                }

                return instance;
            }
        }

        public List<DiseaseLight> Diseases
        {
            get;
            set;
        }

        public DateTime DateCached
        {
            get;
            set;
        }

        public bool IsCacheValid()
        {
            if (Diseases != null && Diseases.Count > 0 && DateCached > DateTime.Now.AddHours(-6))
            {
                return true;
            }

            return false;
        }
        public List<DiseaseLight> GetCache()
        {
            if (IsCacheValid())
                return Diseases;
            return null;
        }

        public void SetCache(List<DiseaseLight> diseases)
        {
            this.Diseases = diseases;
            this.DateCached = DateTime.Now;
        }
    }

    public class DiseaseService
    {

        public async Task<List<DiseaseLight>> Search(string searchstr)
        {
            return await ApiClient.Instance.Get<List<DiseaseLight>>(Configurations.API_BASE_URL + "/diseases/search?searchstr=" + searchstr);
        }

        public async Task<List<DiseaseLight>> List()
        {
            var cache = DiseaseCache.Instance.GetCache();

            if (cache != null)
                return cache;

            var diseases = await ApiClient.Instance.Get<List<DiseaseLight>>(Configurations.API_BASE_URL + "/diseases");
            DiseaseCache.Instance.SetCache(diseases);
            return diseases;
        }

        public async Task<Disease> GetDisease(int id)
        {
            var res = await ApiClient.Instance.Get<List<Disease>>(Configurations.API_BASE_URL + "/diseases/" + id);

            var ret = res[0];
            //ret.treatment_description = "<body><style>p{font-size: 30px; font-family:\"Arial\", Sans-serif;}</style>" + ret.treatment_description + "</body>";
            return ret;
        }


    }
}
