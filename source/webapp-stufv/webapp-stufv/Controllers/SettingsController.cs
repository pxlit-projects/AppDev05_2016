using System;
using System.Collections.Generic;
using System.IO;
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
            List<User> allUsers = iuser.GetAllUsers();
            User user = allUsers.Single(r => r.Id == (int)Session["userId"]);
            return View(user);
        }
        public ActionResult ChangeSettings() {
            Index();
            return View(@"~\Views\Settings\Index.cshtml");
        }
        public ActionResult ProfileImgUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath(@"..\Content\img\ProfilePictures\"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            //Change user profile picture
            int userId = (int)Session["userId"];
            using (var context = new STUFVModelContext())
            {
                var user = context.Users.FirstOrDefault(c => c.Id == userId);
                user.ProfilePicture = file.FileName;
                context.SaveChanges();
            }
            Index();
            return View(@"~\Views\Settings\Index.cshtml");
        }
    }
}