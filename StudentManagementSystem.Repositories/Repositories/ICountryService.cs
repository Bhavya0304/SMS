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
        Task<int> AddCountryAsync(Country data);
        int EditCountry(Country data);
        Task<int> EditCountryAsync(Country data);
        Country GetCountry(int id);
        int DeleteCountry(int id);
        Task<int> DeleteCountryAsync(int id);

        List<Country> GetAllCountries();
        Task<List<Country>> GetAllCountriesAsync();
        List<Country> GetAllCountriesOffset(int length, int offset);

        int GetTotalLength();
    }
}
