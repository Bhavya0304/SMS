using StudentManagementSystem.Helpers.Helpers;
using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    [NoCache]
    public class TeacherController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly ITeacherService teacherService;
        public ICountryService countryService;
        public IStateService stateService;
        public ICityService cityService;

        public TeacherController(ISubjectService _subjectService, ITeacherService _teacherService, ICountryService _countryService, IStateService _stateService, ICityService _cityService)
        {
            subjectService = _subjectService;
            teacherService = _teacherService;
            countryService = _countryService;
            stateService = _stateService;
            cityService = _cityService;
            
        }
      

        public void BindAllAddress(int CountryId,int StateId)
        {
            ViewBag.countryname = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            ViewBag.states = new SelectList(stateService.GetStateAccordingToCountry(Convert.ToInt32(CountryId)), "Id", "StateName");
            ViewBag.cities = new SelectList(cityService.GetCityAccordingToState(Convert.ToInt32(StateId)), "Id", "CityName");
        }
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllSubject()
        {

            return View(subjectService.GetAllSubject());
        }

        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject data)
        {
            if (ModelState.IsValid)
            {
                int status = subjectService.AddSubject(data);
                if (status == 1)
                {
                    return RedirectToAction("AllSubject");
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            return View();
        }

        public ActionResult EditSubject(int id)
        {
            Subject subject = subjectService.GetSubject(id);
            return View(subject);
        }
        [HttpPost]
        public ActionResult EditSubject(Subject subject)
        {
            if (ModelState.IsValid)
            {
                int status = subjectService.UpdateSubject(subject);
                if (status == 1)
                {
                    return RedirectToAction("AllSubject");
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong!";
                }
            }
            return View();
        }

        public ActionResult DeleteSubject(int id)
        {
            int status = subjectService.DeleteSubject(id);
            if (status != 1)
            {
                TempData["Error"] = "Something Went Wrong!";
            }
            return RedirectToAction("AllSubject");
        }

        public ActionResult AllTeacher()
        {
            List<getTeacherData_Result> teachers = teacherService.GetTeacherForDisplay();
            return View(teachers);
        }

        public ActionResult AddTeacher()
        {
            ViewBag.countryname = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            ViewBag.Subjects = new SelectList(subjectService.GetAllSubject(), "Id", "SubjectName");
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                int status = teacherService.AddTeacher(teacher);
                if (status == 1)
                {
                    return RedirectToAction("AllTeacher");
                }
                else
                {
                    ViewBag.Error = "Seomthing Went Wrong!";
                }
            }
            ViewBag.countryname = new SelectList(countryService.GetAllCountries(), "Id", "CountryName");
            ViewBag.Subjects = new SelectList(subjectService.GetAllSubject(), "Id", "SubjectName");
            return View(teacher);
        }

        public ActionResult EditTeacher(int id)
        {
            Teacher teacher = teacherService.GetTeacher(id);
            ViewBag.DOB = teacher.DOB.Value.ToString("yyyy-MM-dd");
            BindAllAddress(Convert.ToInt32(teacher.Country),Convert.ToInt32(teacher.State));
            ViewBag.Subjects = new SelectList(subjectService.GetAllSubject(), "Id", "SubjectName");
            return View(teacher);
        }

        [HttpPost]
        public ActionResult EditTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                int status = teacherService.UpdateTeacher(teacher);
                if(status == 1)
                {
                    return RedirectToAction("AllTeacher");
                }
                else
                {
                    ViewBag.Error = "Soemthing Went Wrong!";
                }
            }
            ViewBag.DOB = teacher.DOB.Value.ToString("yyyy-MM-dd");
            BindAllAddress(Convert.ToInt32(teacher.Country), Convert.ToInt32(teacher.State));
            ViewBag.Subjects = new SelectList(subjectService.GetAllSubject(), "Id", "SubjectName");
            return View(teacher);
        }

        public ActionResult DeleteTeacher(int id)
        {
            int status = teacherService.DeleteTeacher(id);
            if(status != 1)
            {
                TempData["Error"] = "Something Went Wrong!";
            }
            return RedirectToAction("AllTeacher");
        }
    }
}