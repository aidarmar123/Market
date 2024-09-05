using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Service
{
    public static class NetManager
    {
        public static string URL = "http://localhost:55419/";
        public static HttpClient httpClient = new HttpClient();

        public static async Task<T> Get<T>(string path)
        {
                var response = await httpClient.GetAsync(URL + path);
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(content);
                return data;
            
           
            
        }

        public static async Task<HttpResponseMessage> Post<T>(string path, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var response = await httpClient.PostAsync(URL+path, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return response;
        }

        public static async Task<HttpResponseMessage> Put<T>(string path, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var response = await httpClient.PutAsync(URL + path, new StringContent(json, Encoding.UTF8, "application/json"));
            return response;
        }
        public static async Task<HttpResponseMessage> Delete(string path)
        {
            var response = await httpClient.DeleteAsync(URL+path);
            return response;
        }
    }
}
