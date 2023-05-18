using Newtonsoft.Json;
using StudentManagementSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Helpers.Helpers
{
    public class WebAPI
    {

        public async Task<IList<Country>> GetCountries()
        {
            try
            {
                IList<Country> data;
                HttpClient httpRequest = new HttpClient();
                httpRequest.BaseAddress = new Uri("http://localhost:50000/api/Country");
                var Reponse = await httpRequest.GetAsync("Country");
                var StringData = await Reponse.Content.ReadAsStringAsync();
                var Data = JsonConvert.DeserializeObject<List<Country>>(StringData);
                data = (List<Country>)Data;
                return data;
            }
            catch(Exception e)
            {
                throw e;
            }
        }


    }
}
