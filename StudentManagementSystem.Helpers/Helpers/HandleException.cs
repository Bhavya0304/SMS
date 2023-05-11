using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentManagementSystem.Helpers.Helpers
{
    public class HandleException : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Home/Error");
            filterContext.ExceptionHandled = true;
        }
    }
}
