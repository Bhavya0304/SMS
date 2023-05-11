using StudentManagementSystem.Models.Context;
using StudentManagementSystem.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Services
{
    public class StudentService : IStudentService
    {
        public int AddStudent(Student data)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    _db.Students.Add(data);
                    _db.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int DeleteStudent(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Student stu = _db.Students.Where(x => x.Id == id).FirstOrDefault();
                    _db.Students.Remove(stu);
                    _db.SaveChanges();
                }
                return 1;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public int EditStudent(Student data)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {

                    var stu = _db.Students.ToList().Find(x => x.Id == data.Id);
                    _db.Entry(stu).CurrentValues.SetValues(data);
                    _db.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students;
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    students = _db.Students.ToList();
                }
            }
            catch (Exception e)
            {
                students = new List<Student>();
            }
            return students;
        }

        public Student GetStudent(int id)
        {
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Student data = _db.Students.Where(x => x.Id == id).FirstOrDefault();
                    return data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int TotalStudents()
        {
            int Totals = 0;
            try
            {
                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    Totals = Convert.ToInt32(_db.Students.ToList().Count);
                }
                return Totals;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
