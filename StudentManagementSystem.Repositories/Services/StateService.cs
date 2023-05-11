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
    public class StateService : IStateService
    {
        public int AddState(State data)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    bool val = _db.States.Any(x => x.StateName == data.StateName && x.CountryId == data.CountryId);
                    if (val)
                    {
                        return 2;
                    }
                    else
                    {
                        _db.States.Add(data);
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

        public int DeleteState(int id)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    if (_db.Students.Any(x => x.State == id))
                    {
                        return 2;
                    }
                    if (_db.Cities.Any(x => x.StateId == id))
                    {
                        return 3;
                    }
                    State states = _db.States.Where(x => x.Id == id).FirstOrDefault();
                    _db.States.Remove(states);
                    _db.SaveChanges();
                    return 1;

                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int EditState(State data)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    bool val = _db.States.Any(x => x.StateName == data.StateName && x.CountryId == data.CountryId);
                    if (val)
                    {
                        return 2;
                    }
                    else
                    {
                        var state = _db.States.ToList().Find(x => x.Id == data.Id);
                        _db.Entry(state).CurrentValues.SetValues(data);
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

        public List<State> GetAllStates()
        {
            List<State> states;
            using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
            {
                states = _db.States.Include("Country").ToList();
            }
            return states;
        }

        public State GetSingleStates(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    State data = _db.States.Where(x => x.Id == id).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<State> GetStateAccordingToCountry(int CountryId)
        {
            try
            {

                List<State> states;
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    states = _db.States.Where(x => x.CountryId == CountryId).ToList();
                }
                return states;
            }
            catch (Exception e)
            {
                return new List<State>();
            }
        }

    }
}
