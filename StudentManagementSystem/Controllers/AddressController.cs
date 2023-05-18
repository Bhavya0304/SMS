using StudentManagementSystem.Models;
using System;
using StudentManagementSystem.Repositories.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Helpers.Helpers;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    [NoCache]
    [Authorize]
    public class AddressController : Controller
    {
        
        public ICityService cityService;
        public IStateService stateService;
        public ICountryService countryService;
        public AddressController(ICityService _cityService,IStateService _stateService,ICountryService _countryService)
        {
            cityService = _cityService;
            stateService = _stateService;
            countryService = _countryService;
        }

        public void BindTempData()
        {
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"].ToString();
            }
            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"].ToString();
            }
        }

        public ActionResult AddCountry()
        {
            BindTempData();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddCountry(Country data)
        {
            if (ModelState.IsValid)
            {

                //int status = countryService.AddCountry(data);
                HttpCall<Country> http = new HttpCall<Country>();
                int status = await http.CallPost("http://localhost:50000/api/Country", "Country", data);
                if(status == 1)
                {
                    return RedirectToAction("AllCountry");
                }
                else if(status == 2)
                {
                    ViewBag.Error = "Country Already Exists";
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            return View();
        }

        public async Task<ActionResult> AllCountry()
        {
            BindTempData();
            HttpCall<List<Country>> data = new HttpCall<List<Country>>();
            var res = await data.CallGet("http://localhost:50000/api/Country", "Country");
           
            List<Country> newData = (List<Country>) res;
            return View(countryService.GetAllCountries());
        }
        public JsonResult GetCountrysss()
        {
            int offset = Convert.ToInt32(HttpContext.Request.Params["start"]);
            int length = Convert.ToInt32(HttpContext.Request.Params["length"]);
            int draw = Convert.ToInt32(HttpContext.Request.Params["draw"]);
            var data = (from a in countryService.GetAllCountriesOffset(length, offset) select new { CountryName = a.CountryName, Id = a.Id }).ToList();
            var obj =
            new
            {
                data = data,
                draw = draw,
                recordsFiltered = countryService.GetTotalLength(),
                recordsTotal = countryService.GetTotalLength()
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditCountry(int id)
        {
            BindTempData();
            Country country = countryService.GetCountry(id);
            if(country == null)
            {
                TempData["Error"] = "Something Went Wrong";
                return RedirectToAction("AllCountry");
            }
            else
            {
                return View(country);
            }
        }
        [HttpPost]
        public ActionResult EditCountry(Country data)
        {
            if (ModelState.IsValid)
            {
                int status = countryService.EditCountry(data);
                if(status == 1)
                {
                    return RedirectToAction("AllCountry");
                }
                else if (status == 2)
                {
                    ViewBag.Error = "Country Already Exists";
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            return View();
        }

        public ActionResult DeleteCountry(int id)
        {
            int status = countryService.DeleteCountry(id);
            if(status == 2)
            {
                TempData["Error"] = "Student lives in this country!";
            }
            else if (status == 3)
            {
                TempData["Error"] = "State in this country exists!";
            }
            else if(status == 0)
            {
                TempData["Error"] = "Something went wrong!";
            }
            return RedirectToAction("AllCountry");
        }

        public ActionResult AllState()
        {
            BindTempData();
            State st = new State();
            return View(stateService.GetAllStates());
        }
        public ActionResult AddState()
        {
            ViewBag.Country = new SelectList(countryService.GetAllCountries(),"Id","CountryName");
            BindTempData();
            return View();
        }

        [HttpPost]
        public ActionResult AddState(State data)
        {
            if (ModelState.IsValid)
            {

                int status = stateService.AddState(data);
                if (status == 1)
                {
                    return RedirectToAction("AllState");
                }
                else if (status == 2)
                {
                    ViewBag.Error = "State Already Exists";
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            ViewBag.Country = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            return View();
        }

        public ActionResult EditState(int id)
        {
            BindTempData();
            ViewBag.Country = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            State state = stateService.GetSingleStates(id);
            if (state == null)
            {
                TempData["Error"] = "Something Went Wrong";
                return RedirectToAction("AllState");
            }
            else
            {
                return View(state);
            }
        }
        [HttpPost]
        public ActionResult EditState(State data)
        {
            if (ModelState.IsValid)
            {
                int status = stateService.EditState(data);
                if (status == 1)
                {
                    return RedirectToAction("AllState");
                }
                else if (status == 2)
                {
                    ViewBag.Error = "State Already Exists";
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            ViewBag.Country = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            return View(data);
        }
        public ActionResult DeleteState(int id)
        {
            int status = stateService.DeleteState(id);

            if (status == 2)
            {
                TempData["Error"] = "Student lives in this State!";
            }
            else if (status == 3)
            {
                TempData["Error"] = "City in this state exists!";
            }
            else if(status == 0)
            {
                TempData["Error"] = "Something Went Wrong!";
            }
            return RedirectToAction("AllState");
        }

        public ActionResult AllCity()
        {
            BindTempData();
            City st = new City();
            return View(cityService.GetAllCity());
        }

        public ActionResult AddCity()
        {
            ViewBag.Country = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            BindTempData();
            return View();
        }

        [HttpPost]
        public ActionResult AddCity(City data)
        {
            if (ModelState.IsValid)
            {

                int status = cityService.AddCity(data);
                if (status == 1)
                {
                    return RedirectToAction("AllCity");
                }
                else if (status == 2)
                {
                    ViewBag.Error = "State Already Exists";
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            ViewBag.Country = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            return View();
        }

        public ActionResult EditCity(int id)
        {
            BindTempData();
            City city = cityService.GetSingleCity(id);
            ViewBag.Country = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            ViewBag.State = new SelectList(stateService.GetStateAccordingToCountry(Convert.ToInt32(city.CountryId)),"Id","StateName");
            if (city == null)
            {
                TempData["Error"] = "Something Went Wrong";
                return RedirectToAction("AllCity");
            }
            else
            {
                return View(city);
            }
        }
        [HttpPost]
        public ActionResult Editcity(City data)
        {
            if (ModelState.IsValid)
            {
                int status = cityService.EditCity(data);
                if (status == 1)
                {
                    return RedirectToAction("AllCity");
                }
                else if (status == 2)
                {
                    ViewBag.Error = "City Already Exists";
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            ViewBag.Country = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            ViewBag.State = new SelectList(stateService.GetStateAccordingToCountry(Convert.ToInt32(data.CountryId)), "Id", "StateName");
            return View(data);
        }
        public ActionResult DeleteCity(int id)
        {
            int status = cityService.DeleteCity(id);
            if (status == 2)
            {
                TempData["Error"] = "Student lives in this City!";
            }
            else if (status == 3)
            {
                TempData["Error"] = "City in this state exists!";
            }
            else if(status == 0)
            {
                TempData["Error"] = "Something Went Wrong!";
            }
            return RedirectToAction("AllCity");
        }

    }
}