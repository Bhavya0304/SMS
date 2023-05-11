using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using StudentManagementSystem.Helpers.Helpers;

namespace StudentManagementSystem.Controllers
{
    [NoCache]
    public class AccountController : Controller
    {
        public IUserService userService;
        public AccountController(IUserService _userService)
        {
            userService = _userService;
            
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

        
        // GET: Account
        public ActionResult Login()
        {
            BindTempData();
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(SMS_User _User)
        {
            SMS_User loggeduser = userService.Login(_User);
            if(loggeduser != null)
            {
                var authTicket = new FormsAuthenticationTicket(
               1,
               _User.Email,
               DateTime.Now,
               DateTime.Now.AddDays(5),
               _User.RememberMe,
               "Admin"
                );

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

               
                TempData["Success"] = "Login SuccessFull!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Email", "Incorrect Username or Password!");
                ModelState.AddModelError("Password", "...");
                return View(_User);
            }
        }

        public ActionResult Register()
        {
            BindTempData();
            return View();
        }

        [HttpPost]
        public ActionResult Register(SMS_User user)
        {
            int status = userService.Register(user);
            if(status == 1)
            {
                TempData["Success"] = "Registration SuccessFull";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = "Something Went Wrong!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}