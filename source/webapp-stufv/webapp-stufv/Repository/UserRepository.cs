using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool Exist(string email)
        {
            List<User> users = GetAllUsers();
            int x;
            for (x = 0; x < users.Count(); x++)
            {
                if (users.ElementAt(x).Email.Equals(email) && users.ElementAt(x).Active)
                {
                    return true;
                }
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            using (var context = new STUFVModelContext())
            {
                List<User> users = new List<User>();
                users = context.Users.ToList();
                return users;
            }
        }

        public string GetSalt(string email)
        {
            String salt = "";

            List<User> users = GetAllUsers();
            salt = users.Single(u => u.Email == email).Salt;
            return salt;
        }

        public bool InsertUser(List<string> values)
        {
            return true;
        }

        public bool Login(string email, string password, out int userID)
        {
            using (var context = new STUFVModelContext())
            {
                List<User> users = context.Users.ToList();

                int x;
                for (x = 0; x < users.Count(); x++)
                {
                    if (users.ElementAt(x).Email.Equals(email) && users.ElementAt(x).PassWord.Equals(password))
                    {
                        userID = (int)users.ElementAt(x).Id;
                        return true;
                    }

                }
                userID = 0;
                return false;
            }
        }
    }
}