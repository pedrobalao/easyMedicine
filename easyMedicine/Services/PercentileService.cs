using System;
using System.Globalization;
using System.Threading.Tasks;
using easyMedicine.Models;

namespace easyMedicine.Services
{
    public class PercentileService
    {

        public PercentileService()
        {

        }

        public async Task<Percentile> GetHeightPercentile(Gender gender, DateTime birthdate, decimal height)
        {
            return await ApiClient.Instance.Get<Percentile>(Configurations.API_BASE_URL + "/height/percentile/" + Enum.GetName(typeof(Gender), gender) + "/" + birthdate.ToString("yyyy-MM-dd") + "/" + height.ToString("G", CultureInfo.InvariantCulture));
        }

        public async Task<Percentile> GetWeightPercentile(Gender gender, DateTime birthdate, decimal weight)
        {
            return await ApiClient.Instance.Get<Percentile>(Configurations.API_BASE_URL + "/weight/percentile/" + Enum.GetName(typeof(Gender), gender) + "/" + birthdate.ToString("yyyy-MM-dd") + "/" + weight.ToString("G", CultureInfo.InvariantCulture));
        }

        public async Task<decimal> GetBMI(decimal weight, decimal height)
        {
            return await ApiClient.Instance.Get<decimal>(Configurations.API_BASE_URL + "/bmi/calculation?weight=" + weight.ToString("G", CultureInfo.InvariantCulture) + "&height=" + height.ToString("G", CultureInfo.InvariantCulture));
        }

        public async Task<Percentile> GetBMIPercentile(Gender gender, DateTime birthdate, decimal bmi)
        {
            return await ApiClient.Instance.Get<Percentile>(Configurations.API_BASE_URL + "/bmi/percentile/" + Enum.GetName(typeof(Gender), gender) + "/" + birthdate.ToString("yyyy-MM-dd") + "/" + bmi.ToString("G", CultureInfo.InvariantCulture));
        }


    }
}
