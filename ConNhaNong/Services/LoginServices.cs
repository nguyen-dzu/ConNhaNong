using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConNhaNong.Models;

namespace ConNhaNong.Services
{
    public static class LoginServices
    {
        public static CT25Team18Entities1 context = new CT25Team18Entities1();
        public static bool Login(string Email, string Pass)
        {
            var User = context.Users.Where(s => s.Email.Equals(Email)).FirstOrDefault();
            if (User != null)
            {
                if (User.Passwords.Equals(Pass))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
        public static bool CheckRegister(string Email, string Pass)
        {
            var User = context.Users.Where(s => s.Email.Equals(Email)).FirstOrDefault();
            if (User != null)
            {
                return false;
            }
            else
            {
                return true;
            }    
        }
        public static void Regiter(string Email, string Pass)
        {
            string Id = Services.IDServices.RandomIDUser();
            var Use = context.Users.Where(s => s.ID.Equals(Id)).FirstOrDefault();
            while (Use != null)
            {
                Id = Services.IDServices.RandomIDUser();
            }
            User user = new User();
            user.Email = Email;
            user.Passwords = Pass;
            user.ID = Id;
            context.Users.Add(user);
            context.SaveChanges();
        }

    }
}