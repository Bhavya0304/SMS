using Newtonsoft.Json;
using StudentManagementSystem.Helpers.Helpers;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    [NoCache]
    public class HomeController : Controller
    {
        
        public ICountryService countryService;
        public IStateService stateService;
        public ICityService cityService;
        public ITeacherService teacherService;
        public IStudentService studentService;
        public ISubjectService subjectService;
        public WebAPI api = new WebAPI();


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

       
        public HomeController(ICountryService _countryService, IStateService _stateService, ICityService _cityService, ITeacherService _teacherService,IStudentService _studentService, ISubjectService _subjectService)
        {
            countryService = _countryService;
            stateService = _stateService;
            cityService = _cityService;
            teacherService = _teacherService;
            studentService = _studentService;
            subjectService = _subjectService;
          
        }
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.TotalStudents = studentService.TotalStudents();
            ViewBag.TotalSubjects = subjectService.TotalSubjects();
            ViewBag.TotalTeachers = teacherService.TotalTeachers();
            BindTempData();
            return View();
        }
        [Authorize]
        public ActionResult AddStudent()
        {
            BindTempData();
            ViewBag.countryname = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            ViewBag.Teachers = new SelectList(teacherService.GetAllTeachers(), "Id", "FirstName");
            return View();
        }

        [Authorize]
        [HttpPost]
        public  ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {

                int status = studentService.AddStudent(student);
                if(status == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }

            ViewBag.countryname = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            ViewBag.Teachers = new SelectList(teacherService.GetAllTeachers(), "Id", "FirstName");
            return View();
            
        }

        [Authorize]
        public ActionResult DeleteStudent(int id)
        {
            int status = studentService.DeleteStudent(id);
            if(status != 1)
            {
                TempData["Error"] = "Something Went Wrong!";
            }
            return RedirectToAction("AllStudents");
        }

        [Authorize]
        public ActionResult EditStudent(int id)
        {
            BindTempData();
            Student data = studentService.GetStudent(id);
            if(data == null)
            {
                TempData["Error"] = "Something Went Wrong!";
                return RedirectToAction("AllStudents");
            }

            ViewBag.DOB = data.DOB.ToString("yyyy-MM-dd");
            ViewBag.countryname = new SelectList(countryService.GetAllCountries(),"Id","CountryName");
            ViewBag.states = new SelectList(stateService.GetStateAccordingToCountry(Convert.ToInt32(data.Country)), "Id", "StateName");
            ViewBag.cities = new SelectList(cityService.GetCityAccordingToState(Convert.ToInt32(data.State)), "Id", "CityName");
            ViewBag.Teachers = new SelectList(teacherService.GetAllTeachers(), "Id", "FirstName");
            return View(data);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditStudent(Student data)
        {

            if (ModelState.IsValid)
            {
                int status = studentService.EditStudent(data);
                if(status == 1)
                {
                    return RedirectToAction("AllStudents");
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            ViewBag.DOB = data.DOB.ToString("yyyy-MM-dd");
            ViewBag.countryname = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            ViewBag.states = new SelectList(stateService.GetStateAccordingToCountry(Convert.ToInt32(data.Country)), "Id", "StateName");
            ViewBag.cities = new SelectList(cityService.GetCityAccordingToState(Convert.ToInt32(data.State)),"Id","CityName");
            ViewBag.Teachers = new SelectList(teacherService.GetAllTeachers(), "Id", "FirstName");
            return View(data);
        }


        [Authorize]
        public ActionResult AllStudents()
        {
            BindTempData();
            List<getStudentData_Result> data = new BJBhavyaJoshiEntities().getStudentData(null).ToList();
            return View(data);
        }
        public JsonResult GetState(int id)
        {
            List<State> states = stateService.GetStateAccordingToCountry(Convert.ToInt32(id));
            var state = from s in states select new { StateName = s.StateName, Id = s.Id };
            return Json(state, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCity(int id)
        {
            List<City> cities = cityService.GetCityAccordingToState(id);
            var city = from c in cities select new { CityName = c.CityName, Id = c.Id };
            return Json(city, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Error()
        {
            return View();
        }


    }
}