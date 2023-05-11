using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Services
{
    public class CountryService : ICountryService
    {
        public int AddCountry(Country data)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    bool val = _db.Countries.Any(x => x.CountryName == data.CountryName);
                    if (val)
                    {
                        return 2;
                    }
                    else
                    {
                        _db.Countries.Add(data);
                        _db.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int DeleteCountry(int id)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    if (_db.Students.Any(x => x.Country == id))
                    {
                        return 2;
                    }
                    if (_db.States.Any(x => x.CountryId == id))
                    {
                        return 3;
                    }
                    Country country = _db.Countries.Where(x => x.Id == id).FirstOrDefault();
                    _db.Countries.Remove(country);
                    _db.SaveChanges();
                    return 1;

                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int EditCountry(Country data)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    bool val = _db.Countries.Any(x => x.CountryName == data.CountryName);
                    if (val)
                    {
                        return 2;
                    }
                    else
                    {
                        var country = _db.Countries.ToList().Find(x => x.Id == data.Id);
                        _db.Entry(country).CurrentValues.SetValues(data);
                        _db.SaveChanges();
                        return 1;
                    }

                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public List<Country> GetAllCountries()
        {
                try
                {

                    List<Country> country;
                    using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                    {
                        country = _db.Countries.ToList();
                    }
                    return country;
                }
                catch (Exception e)
                {
                    return new List<Country>();
                }
        }

        public Country GetCountry(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Country data = _db.Countries.Where(x => x.Id == id).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
