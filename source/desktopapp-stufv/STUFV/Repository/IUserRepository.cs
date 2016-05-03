using System;
using System.Collections.Generic;

namespace STUFV.Repository
{
    public interface IUserRepository
    {
        Boolean Login(string email, string password, out int userID);
        List<User> GetAllUsers();
        Boolean Exist(string email);
        String GetSalt(string email);
        Boolean InsertUser(List<string> values);
    }
}
