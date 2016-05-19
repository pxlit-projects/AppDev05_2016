using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers
{
    public class AccountController : Controller
    {
        private IOrganisationRepository iorganisation = new OrganisationRepository();
        private IUserRepository iuser = new UserRepository();

        public ActionResult Register()
        {
            ViewBag.Title = "Registratie";
            return View();
        }
        public ActionResult Process()
        {
            var email = Request.Form["Email"].ToLower();
            var password = Request.Form["Password"];

            if (iuser.Exist(email))
            {
                int userID;
                var encPass = MD5Encrypt(password, iuser.GetSalt(email));
                if (iuser.Login(email, encPass, out userID))
                {
                    Session["email"] = email;
                    Session["userId"] = userID;
                    Session["organisation"] = iorganisation.HasOrganisation(userID);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ViewBag.Title = "Login mislukt";
                    Session["email"] = "";
                    Session["userId"] = "";
                    Session["organisation"] = "";
                    return View();
                }
            }
            else {
                ViewBag.Title = "Deze gebruiker bestaat nog niet.";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["Email"] = "";
            Session["userId"] = "";
            Session["organisation"] = "";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CreateAccount()
        {
            String email = Request.Form["Email"];
            if (iuser.Exist(email))
            {
                ViewBag.Title = "Registratie mislukt.";
                ViewBag.Comment = "Dit email adress is al in gebruik";
            }
            else {
                CreateUser(email);
                ViewBag.Title = "Registratie";
                ViewBag.Comment = "Registratie Gelukt";
            }
            return View();
        }
        public ActionResult ChangePassword()
        {
            string salt = iuser.GetSalt(Session["Email"].ToString());
            var encpass = MD5Encrypt(Request.Form["OldPass"], salt);
            int userId = (int)Session["userId"];
            using (var context = new STUFVModelContext())
            {
                User user = context.Users.Single(e => e.Id == userId);
                if (encpass == user.PassWord)
                {
                    var newpass = MD5Encrypt(Request.Form["NewPass"], salt);
                    user.PassWord = newpass;
                    context.SaveChanges();
                }
                else {
                    return View();
                }
            }
            return RedirectToAction("Index", "Settings");
        }
        private void CreateUser(String email)
        {
            String firstName = Request.Form["FirstName"];
            String lastName = Request.Form["LastName"];
            String password = Request.Form["PassWord"];
            DateTime birthDate = DateTime.Parse(Request.Form["BirthDate"]);
            String birthPlace = Request.Form["BirthPlace"];
            String sex = Request.Form["Sex"];
            String street = Request.Form["Street"];
            String zipCode = Request.Form["ZipCode"];
            String telNr = Request.Form["TelNr"];
            String mobileNr = Request.Form["MobileNr"];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            String salt = GenerateRandomSalt(rng, 16);
            String encPass = MD5Encrypt(password, salt);
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                PassWord = encPass,
                BirthDate = birthDate,
                BirthPlace = birthPlace,
                Street = street,
                ZipCode = zipCode,
                Sex = sex,
                TelNr = telNr,
                MobileNr = mobileNr,
                Salt = salt,
                Active = true,
                RoleID = 1,
                Email = email.ToLower(),
                ProfilePicture = "noimageavailable.png"
            };
            int userId = iuser.GetAllUsers().Single(e => e.Email == email).Id;
            var settings = new ProfileSettings
            {
                FirstName = true,
                LastName = true,
                BirthDate = true,
                Street = false,
                ZipCode = true,
                TelNr = false,
                MobileNr = false,
                Email = true,
                UserId = userId
            };
            using (var context = new STUFVModelContext())
            {
                context.Users.Add(user);
                context.ProfileSettings.Add(settings);
                context.SaveChanges();
            }
        }
        private string GenerateRandomSalt(RNGCryptoServiceProvider rng, int size)
        {
            var bytes = new Byte[size];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
        private static string MD5Encrypt(string password, string salt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(salt + password));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}