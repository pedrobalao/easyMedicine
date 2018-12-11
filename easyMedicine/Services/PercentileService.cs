using System;
using System.Globalization;
using System.Threading.Tasks;
using easyMedicine.Models;

namespace easyMedicine.Services
{
    public class PercentileService
    {
        string apiBaseUrl = "https://easypedapi.azurewebsites.net/api/v1";

        public PercentileService()
        {

        }

        public async Task<Percentile> GetHeightPercentile(Gender gender, DateTime birthdate, decimal height)
        {
            return await ApiClient.Instance.Get<Percentile>(apiBaseUrl + "/height/percentile/" + Enum.GetName(typeof(Gender), gender) + "/" + birthdate.ToString("yyyy-MM-dd") + "/" + height.ToString("G", CultureInfo.InvariantCulture));
        }

        public async Task<Percentile> GetWeightPercentile(Gender gender, DateTime birthdate, decimal height)
        {
            return await ApiClient.Instance.Get<Percentile>(apiBaseUrl + "/weight/percentile/" + Enum.GetName(typeof(Gender), gender) + "/" + birthdate.ToString("yyyy-MM-dd") + "/" + height.ToString("G", CultureInfo.InvariantCulture));
        }

    }
}
