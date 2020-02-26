using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace easyMedicine.Services
{

    public sealed class ApiClient
    {
        private static ApiClient instance = null;
        private static readonly object padlock = new object();


        readonly HttpClient _httpClient;
        private JsonSerializer _serializer = new JsonSerializer();

        ApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> Get<T>(string url)
        {
            await SetHeaders();

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(json);
            }
        }

        public async Task Patch<T>(string url, T item)
        {
            await SetHeaders();

            var jsonRequest = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync(url, content);
            response.EnsureSuccessStatusCode();

            return;
        }

        public async Task Post<T>(string url, T item)
        {
            await SetHeaders();

            var jsonRequest = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            return;
        }

        public async Task SetHeaders()
        {
            var token = await AuthenticationService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static ApiClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ApiClient();
                    }
                    return instance;
                }
            }
        }
    }
}

