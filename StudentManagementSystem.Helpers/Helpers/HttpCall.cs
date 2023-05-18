using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Helpers.Helpers
{
    public class HttpCall<T>
    {
        HttpClient http = new HttpClient();
        public async Task<T> CallGet(string URL,string Controller)
        {
            http.BaseAddress = new Uri(URL);
            var response = await http.GetAsync(Controller);
            var result = await response.Content.ReadAsStringAsync();
            T data = JsonConvert.DeserializeObject<T>(result);
            return data;
        }

        public async Task<int> CallPost(string URL,string Controller,T data)
        {
            var strObj = JsonConvert.SerializeObject(data);
            var requestBody = new StringContent(strObj, Encoding.UTF8, "application/json");
            http.BaseAddress = new Uri(URL);
            var response = await http.PostAsync(Controller, requestBody);
            return Convert.ToInt32(response.StatusCode);
        }
    }
}
