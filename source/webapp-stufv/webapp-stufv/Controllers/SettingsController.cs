using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult ChangeSettings(HttpPostedFileBase file)
        {
            ProfileImgUpload(file);
            using (var context = new STUFVModelContext())
            {
                int userId = (int)Session["userId"];
                var user = context.Users.FirstOrDefault(c => c.Id == userId);
                user.Street = Request.Form["Street"];
                user.ZipCode = Request.Form["ZipCode"];
                user.MobileNr = Request.Form["MobileNr"];
                user.TelNr = Request.Form["TelNr"];
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Settings");
        }
        public ActionResult DeactivateAccount() {
            using (var context = new STUFVModelContext())
            {
                int userId = (int)Session["userId"];
                context.Users.Single(e => e.Id == userId).Active = false;
                context.SaveChanges();
            }
                return RedirectToAction("Logout", "Account");
        }
        private void ProfileImgUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                int userId = (int)Session["userId"];
                string pic = "ProfilePicture_" + Session["userId"] + ".jpg";
                string path = System.IO.Path.Combine(
                                       Server.MapPath(@"..\Content\img\ProfilePictures\"), pic);
                using (var context = new STUFVModelContext())
                {
                    var user = context.Users.FirstOrDefault(c => c.Id == userId);
                    string oldPath = @"..\Content\img\ProfilePictures\" + user.ProfilePicture;
                    if (System.IO.File.Exists(oldPath)) {
                        System.IO.File.Delete(oldPath);
                    }
                    user.ProfilePicture = pic;
                    context.SaveChanges();
                }
                file.SaveAs(path);
            }
        }
    }
}