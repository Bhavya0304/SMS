using StudentManagementSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Repositories
{
    public interface ISubjectService
    {
        int AddSubject(Subject subject);

        int UpdateSubject(Subject subject);

        int DeleteSubject(int id);

        List<Subject> GetAllSubject();
        int TotalSubjects();
        Subject GetSubject(int id);
    }
}
