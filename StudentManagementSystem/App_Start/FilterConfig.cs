using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Helpers.Helpers;

namespace StudentManagementSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleException());
        }
    }
}
