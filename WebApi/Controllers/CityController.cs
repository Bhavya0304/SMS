using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CityController : ApiController
    {
        ICityService cityService;
        public CityController(ICityService _cityService)
        {
            cityService = _cityService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAllCities()
        {
            List<City> data = await cityService.GetAllCityAsync();
            var newData = from city in data select new { CityName = city.CityName, Id = city.Id };
            return Ok(newData);
        }

    }
}
