using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<int> AddCountryAsync(Country data)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    bool val = await _db.Countries.AnyAsync(x => x.CountryName == data.CountryName);
                    if (val)
                    {
                        return 2;
                    }
                    else
                    {
                        _db.Countries.Add(data);
                        await _db.SaveChangesAsync();
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

        public async Task<int> DeleteCountryAsync(int id)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    if (await _db.Students.AnyAsync(x => x.Country == id))
                    {
                        return 2;
                    }
                    if (await _db.States.AnyAsync(x => x.CountryId == id))
                    {
                        return 3;
                    }
                    Country country = await _db.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();
                    _db.Countries.Remove(country);
                    await _db.SaveChangesAsync();
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

        public async Task<int> EditCountryAsync(Country data)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    bool val = await  _db.Countries.AnyAsync(x => x.CountryName == data.CountryName);
                    if (val)
                    {
                        return 2;
                    }
                    else
                    {
                        List<Country> country = await _db.Countries.ToListAsync();

                         Country oldCountry = country.Find(x => x.Id == data.Id);
                        _db.Entry(oldCountry).CurrentValues.SetValues(data);
                        await _db.SaveChangesAsync();
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

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            try
            {
                List<Country> data;
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    data = await _db.Countries.ToListAsync();
                }

                return data;
            }
            catch (Exception e) { return new List<Country>(); }
        }

        public List<Country> GetAllCountriesOffset(int length,int offset)
        {
            try
            {

                List<Country> country;
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    country = _db.Countries.OrderBy(x=>x.Id).Skip(offset).Take(length).ToList();
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

        public int GetTotalLength()
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    int data = Convert.ToInt32(_db.Countries.ToList().Count);
                    return data;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
