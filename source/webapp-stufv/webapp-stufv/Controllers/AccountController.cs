using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;
using webapp_stufv.Repository;

namespace webapp_stufv.Controllers {
    public class AccountController : Controller {
        private IOrganisationRepository iorganisation = new OrganisationRepository();
        private IUserRepository iuser = new UserRepository();
        // GET: Account
        public ActionResult Login ( ) {
            ViewBag.Title = "Login";
            return View ( );
        }
        public ActionResult Register ( ) {
            ViewBag.Title = "Registratie";
            return View ( );
        }
        public ActionResult Process ( ) {
            var email = Request.Form[ "Email" ].ToLower ( );
            String password = Request.Form[ "Password" ];
            if ( iuser.Exist ( email ) ) {
                int userID;
                String encPass = MD5Encrypt ( password, iuser.GetSalt ( email ) );
                if ( iuser.Login ( email, encPass, out userID ) ) {
                    Session[ "email" ] = email;
                    Session[ "userId" ] = userID;
                    Session[ "organisation" ] = iorganisation.HasOrganisation ( userID );
                    ViewBag.Title = "Succes";
                    return View ( );
                } else {
                    ViewBag.Title = "Login mislukt";
                    Session[ "email" ] = "";
                    Session[ "userId" ] = "";
                    Session[ "organisation" ] = "";
                    return View ( );
                }
            } else {
                ViewBag.Title = "Deze gebruiker bestaat nog niet";
                return View ( );
            }
        }
        public ActionResult Logout ( ) {
            Session[ "Email" ] = "";
            Session[ "userId" ] = "";
            Session[ "organisation" ] = "";
            ViewBag.Title = "Logout gelukt";
            return View ( );
        }

        public ActionResult CreateAccount ( ) {
            String email = Request.Form[ "Email" ];
            if ( iuser.Exist ( email ) ) {
                ViewBag.Title = "Registratie mislukt.";
                ViewBag.Comment = "Dit email adress is al in gebruik";
            } else {
                CreateUser ( email );
                ViewBag.Title = "Registratie";
                ViewBag.Comment = "Registratie Gelukt";
            }
            return View ( );
        }
        private void CreateUser ( String email ) {
            String firstName = Request.Form[ "FirstName" ];
            String lastName = Request.Form[ "LastName" ];
            String password = Request.Form[ "PassWord" ];
            DateTime birthDate = DateTime.Parse ( Request.Form[ "BirthDate" ] );
            String birthPlace = Request.Form[ "BirthPlace" ];
            Char sex = Char.Parse ( Request.Form[ "Sex" ] );
            String zipCode = Request.Form[ "ZipCode" ];
            String telNr = Request.Form[ "TelNr" ];
            String mobileNr = Request.Form[ "MobileNr" ];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider ( );
            String salt = GenerateRandomSalt ( rng, 16 );
            String encPass = MD5Encrypt ( password, salt );
            var user = new User {
                FirstName = firstName,
                LastName = lastName,
                PassWord = encPass,
                BirthDate = birthDate,
                BirthPlace = birthPlace,
                ZipCode = zipCode,
                Sex = sex,
                TelNr = telNr,
                MobileNr = mobileNr,
                Salt = salt,
                Active = true,
                RoleID = 1,
                Email = email.ToLower ( )
            };
            using ( var context = new STUFVModelContext ( ) ) {
                context.Users.Add ( user );
                context.SaveChanges ( );
            }
        }
        private string GenerateRandomSalt ( RNGCryptoServiceProvider rng, int size ) {
            var bytes = new Byte[ size ];
            rng.GetBytes ( bytes );
            return Convert.ToBase64String ( bytes );
        }
        private static string MD5Encrypt ( string password, string salt ) {
            MD5 md5 = new MD5CryptoServiceProvider ( );

            md5.ComputeHash ( ASCIIEncoding.ASCII.GetBytes ( salt + password ) );
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder ( );
            for ( int i = 0 ; i < result.Length ; i++ ) {
                strBuilder.Append ( result[ i ].ToString ( "x2" ) );
            }

            return strBuilder.ToString ( );
        }
    }
}