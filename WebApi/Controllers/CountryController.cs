using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CountryController : ApiController
    {
        ICountryService countryService;
        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public async Task<IHttpActionResult> GetAllCountries()
        {
            List<Country> data = await countryService.GetAllCountriesAsync();
            var newData = from country in data select new { CountryName = country.CountryName, Id = country.Id };
            Response<List<Country>> response = new Response<List<Country>>
            {
                Data = data,
                Status = 200,
                Messege = ""
            };
            return Ok(data);
        }
        [HttpPost]
        public async Task<IHttpActionResult> AddCountry(Country data)
        {
            Response<string> response;
            int status = await countryService.AddCountryAsync(data);
            if(status == 1)
            {
                response = new Response<string>
                {
                    Data = "Success",
                    Status = 200,
                    Messege = ""
                };
            }
            else
            {
                response = new Response<string>
                {
                    Data = "Error",
                    Status = 200,
                    Messege = "Something went wrong!",
                    ExceptionMessege = ""
                };

            }
            return Ok(response);
        }

    }
}
