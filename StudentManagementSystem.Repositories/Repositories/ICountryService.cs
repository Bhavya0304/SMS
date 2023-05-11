using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Repositories
{
    public interface ICountryService
    {
        int AddCountry(Country data);
        int EditCountry(Country data);
        Country GetCountry(int id);
        int DeleteCountry(int id);

        List<Country> GetAllCountries();
    }
}
