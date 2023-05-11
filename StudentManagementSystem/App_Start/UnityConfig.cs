using StudentManagementSystem.Repositories.Repositories;
using StudentManagementSystem.Repositories.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StudentManagementSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICityService, CityService>();
            container.RegisterType<IStateService, StateService>();
            container.RegisterType<ICountryService,CountryService >();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ITeacherService, TeacherService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<IStudentService, StudentService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}