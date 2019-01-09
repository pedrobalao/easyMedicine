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

        public async Task<Percentile> GetWeightPercentile(Gender gender, DateTime birthdate, decimal weight)
        {
            return await ApiClient.Instance.Get<Percentile>(apiBaseUrl + "/weight/percentile/" + Enum.GetName(typeof(Gender), gender) + "/" + birthdate.ToString("yyyy-MM-dd") + "/" + weight.ToString("G", CultureInfo.InvariantCulture));
        }

        public async Task<decimal> GetBMI(decimal weight, decimal height)
        {
            return await ApiClient.Instance.Get<decimal>(apiBaseUrl + "/bmi/calculation?weight=" + weight.ToString("G", CultureInfo.InvariantCulture) + "&height=" + height.ToString("G", CultureInfo.InvariantCulture));
        }

        public async Task<Percentile> GetBMIPercentile(Gender gender, DateTime birthdate, decimal bmi)
        {
            return await ApiClient.Instance.Get<Percentile>(apiBaseUrl + "/bmi/percentile/" + Enum.GetName(typeof(Gender), gender) + "/" + birthdate.ToString("yyyy-MM-dd") + "/" + bmi.ToString("G", CultureInfo.InvariantCulture));
        }


    }
}
