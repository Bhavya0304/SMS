using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Services
{
    public class TeacherService : ITeacherService
    {
        public int AddTeacher(Teacher teacher)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                        _db.Teachers.Add(teacher);
                        _db.SaveChanges();
                        return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int DeleteTeacher(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Teacher teacher = _db.Teachers.Where(x => x.Id == id).FirstOrDefault();
                    _db.Teachers.Remove(teacher);
                    _db.SaveChanges();
                    return 1;

                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {

                List<Teacher> teacher;
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    teacher = _db.Teachers.ToList();
                }
                return teacher;
            }
            catch (Exception e)
            {
                return new List<Teacher>();
            }
        }

        public List<getTeacherData_Result> GetTeacherForDisplay()
        {
            try
            {

                List<getTeacherData_Result> teacher;
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    teacher = _db.getTeacherData(null).ToList();
                }
                return teacher;
            }
            catch (Exception e)
            {
                return new List<getTeacherData_Result>();
            }
        }

        public Teacher GetTeacher(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Teacher data = _db.Teachers.Where(x => x.Id == id).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int UpdateTeacher(Teacher teacher)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    
                        var oldTeacher = _db.Teachers.ToList().Find(x => x.Id == teacher.Id);
                        _db.Entry(oldTeacher).CurrentValues.SetValues(teacher);
                        _db.SaveChanges();
                        return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int TotalTeachers()
        {
            int Totals = 0;
            try
            {
                using(BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Totals = Convert.ToInt32(_db.Teachers.ToList().Count);
                }
                return Totals;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}
