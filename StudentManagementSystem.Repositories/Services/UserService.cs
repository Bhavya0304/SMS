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
    public class UserService : IUserService
    {
        public SMS_User Login(SMS_User user)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    SMS_User usr = _db.SMS_User.ToList().Find(x => x.Email == user.Email && x.Password == user.Password);
                    return usr;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int Register(SMS_User user)
        {
            try
            {

                using (BJBhavyaJoshiEntities _db = new BJBhavyaJoshiEntities())
                {
                    _db.SMS_User.Add(user);
                    _db.SaveChanges();
                }
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
