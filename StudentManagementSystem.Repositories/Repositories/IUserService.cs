using StudentManagementSystem.Models;
using StudentManagementSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repositories.Repositories
{
    public interface IUserService
    {
        SMS_User Login(SMS_User user);
        int Register(SMS_User user);
    }
}
