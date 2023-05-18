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


    public class CityService : ICityService
    {
        public int AddCity(City data)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    bool val = _db.Cities.Any(x => x.CityName == data.CityName);
                    if (val)
                    {
                        return 2;
                    }
                    else
                    {
                        _db.Cities.Add(data);
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

        public int DeleteCity(int id)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    if (_db.Students.Any(x => x.City == id))
                    {
                        return 2;
                    }

                    City city = _db.Cities.Where(x => x.Id == id).FirstOrDefault();
                    _db.Cities.Remove(city);
                    _db.SaveChanges();
                    return 1;

                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int EditCity(City data)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    bool val = _db.Cities.Any(x => x.CityName == data.CityName);
                    if (val)
                    {
                        return 2;
                    }
                    else
                    {
                        var city = _db.Cities.ToList().Find(x => x.Id == data.Id);
                        _db.Entry(city).CurrentValues.SetValues(data);
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

        public List<City> GetAllCity()
        {
            List<City> cities;
            using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
            {
                cities = _db.Cities.Include("State").Include("Country").ToList();
            }
            return cities;
        }

        public City GetSingleCity(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    City data = _db.Cities.Where(x => x.Id == id).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<City> GetCityAccordingToState(int StateId)
        {
            try
            {
                List<City> cities;
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    cities = _db.Cities.Where(x => x.StateId == StateId).ToList();
                }
                return cities;
            }
            catch (Exception e) { return new List<City>(); }
        }

        public async Task<List<City>> GetAllCityAsync()
        {
            try
            {
                List<City> data;
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    data = await _db.Cities.ToListAsync();
                }
               
                return data;
            }
            catch (Exception e) { return new List<City>(); }
            
        }
    }
}
