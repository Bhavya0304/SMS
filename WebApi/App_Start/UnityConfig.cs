using StudentManagementSystem.Repositories.Repositories;
using StudentManagementSystem.Repositories.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
           
            container.RegisterType<ICityService, CityService>();
            container.RegisterType<ICountryService, CountryService>();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}