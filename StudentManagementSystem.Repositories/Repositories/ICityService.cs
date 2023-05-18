using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;

namespace StudentManagementSystem.Repositories.Repositories
{
    public interface ICityService
    {

        int AddCity(City data);

        int EditCity(City data);
        
        int DeleteCity(int id);
        
        City GetSingleCity(int id);
        
        List<City> GetAllCity();
        Task<List<City>> GetAllCityAsync();

        List<City> GetCityAccordingToState(int StateId);

    }
}
