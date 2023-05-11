using StudentManagementSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Repositories
{
    public interface IStudentService
    {
        int AddStudent(Student data);
        int EditStudent(Student data);
        Student GetStudent(int id);
        int DeleteStudent(int id);
        int TotalStudents();
        List<Student> GetAllStudents();
    }
}
