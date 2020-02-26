using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using easyMedicine.Models;

namespace easyMedicine.Services
{
    public class DiseaseService
    {


        public async Task<List<DiseaseLight>> Search(string searchstr)
        {
            return await ApiClient.Instance.Get<List<DiseaseLight>>(Configurations.API_BASE_URL + "/diseases/search?searchstr=" + searchstr);
        }

        public async Task<List<DiseaseLight>> List()
        {
            return await ApiClient.Instance.Get<List<DiseaseLight>>(Configurations.API_BASE_URL + "/diseases");
        }

        public async Task<Disease> GetDisease(int id)
        {
            var res = await ApiClient.Instance.Get<List<Disease>>(Configurations.API_BASE_URL + "/diseases/" + id);

            var ret = res[0];
            ret.treatment_description = "<body><style>p{font-size: 30px; font-family:\"Arial\", Sans-serif;}</style>" + ret.treatment_description + "</body>";
            return ret;
        }


    }
}
