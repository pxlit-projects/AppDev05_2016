using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
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
