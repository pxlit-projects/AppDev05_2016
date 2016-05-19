using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers
{
    public class ProfileController : Controller
    {
        IUserRepository iuser = new UserRepository();
        public ActionResult Index()
        {
            List<User> allUsers = iuser.GetAllUsers();
            return View(allUsers);
        }
        public ActionResult Users(int id)
        {
            List<User> allUsers = iuser.GetAllUsers();
            User user = allUsers.Single(r => r.Id == id);
            ProfileSettings settings = ProfileSettings.GetAllProfileSettings().Single(e => e.UserId == id);
            var tuple = new Tuple<User, ProfileSettings>(user, settings);
            if (!settings.FirstName && !settings.LastName && !settings.BirthDate && !settings.Email &&
                !settings.MobileNr && !settings.Street && !settings.TelNr && !settings.ZipCode)
            {
                ViewBag.Show = false;
            }
            else {
                ViewBag.Show = true;
            }
            return View(tuple);
        }
    }
}