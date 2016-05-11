using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers
{
    public class SettingsController : Controller
    {
        IUserRepository iuser = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            List<User> allUsers = iuser.GetAllUsers();
            User user = allUsers.Single(r => r.Id == (int)Session["userId"]);
            return View(user);
        }
    }
}