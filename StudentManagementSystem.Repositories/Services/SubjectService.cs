using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Services
{
    public class SubjectService : ISubjectService
    {
        public int AddSubject(Subject subject)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    _db.Subjects.Add(subject);
                    _db.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int DeleteSubject(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Subject subject = _db.Subjects.Where(x => x.Id == id).FirstOrDefault();
                    _db.Subjects.Remove(subject);
                    _db.SaveChanges();
                    return 1;

                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public List<Subject> GetAllSubject()
        {
            try
            {

                List<Subject> subject;
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    subject = _db.Subjects.ToList();
                }
                return subject;
            }
            catch (Exception e)
            {
                return new List<Subject>();
            }
        }

        public Subject GetSubject(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Subject data = _db.Subjects.Where(x => x.Id == id).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int TotalSubjects()
        {
            int Totals = 0;
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Totals = Convert.ToInt32(_db.Subjects.ToList().Count);
                }
                return Totals;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int UpdateSubject(Subject subject)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                   
                        var oldSubject = _db.Teachers.ToList().Find(x => x.Id == subject.Id);
                        _db.Entry(oldSubject).CurrentValues.SetValues(subject);
                        _db.SaveChanges();
                        return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
