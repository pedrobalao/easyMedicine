using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace easyMedicine.Helpers
{
    public static class Downloader
    {

        public static async Task<byte[]> DownloadFileAsync(string url)
        {
            var _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };

            try
            {
                using (var httpResponse = await _httpClient.GetAsync(url))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return await httpResponse.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        //Url is Invalid
                        throw new Exception("The file is not available");
                    }
                }
            }
            catch (Exception)
            {
                //Handle Exception
                throw;
            }
        }
    }
}
