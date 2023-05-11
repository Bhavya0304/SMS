using StudentManagementSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Repositories
{
    public interface ITeacherService
    {
        int AddTeacher(Teacher teacher);

        int UpdateTeacher(Teacher teacher);

        int DeleteTeacher(int id);

        List<Teacher> GetAllTeachers();

        Teacher GetTeacher(int id);
        int TotalTeachers();

        List<getTeacherData_Result> GetTeacherForDisplay();
    }
}
