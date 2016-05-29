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

        /*
         * Variables
         */
        private IOrganisationRepository _iorganisation = new OrganisationRepository( );
        private IUserRepository _iuser = new UserRepository( );

        /*
         * Account/Register
         */
        public ActionResult Register( ) {
            if ( Session[ "email" ] == null ) {
                ViewBag.Title = "Registratie";
                return View( );
            } else {
                return RedirectToAction( "Index", "Home" );
            }
        }

        /*
         * Account/Process
         * Processes a login
         */
        public ActionResult Process( ) {
            if ( Session[ "email" ] == null && Request.Form[ "Email" ] != null && Request.Form[ "Password" ] != null ) {
                var email = Request.Form[ "Email" ].ToLower( );
                var password = Request.Form[ "Password" ];

                if ( _iuser.Exist( email ) ) {
                    int userID;
                    var encPass = MD5Encrypt( password, _iuser.GetSalt( email ) );
                    if ( _iuser.Login( email, encPass, out userID ) ) {
                        Session[ "email" ] = email;
                        Session[ "userId" ] = userID;
                        Session[ "organisation" ] = _iorganisation.HasOrganisation( userID );
                        return RedirectToAction( "Index", "Home" );
                    } else {
                        ViewBag.Title = "Oops!";
                        ViewBag.Comment = "Login mislukt.";
                        return View( );
                    }
                } else {
                    ViewBag.Title = "Oops!";
                    ViewBag.Comment = "Deze gebruiker bestaat nog niet.";
                    return View( );
                }
            } else {
                return RedirectToAction( "Index", "Home" );
            }
        }

        /*
         * Account/Logout
         */
        public ActionResult Logout( ) {
            Session.Abandon( );
            return RedirectToAction( "Index", "Home" );
        }

        /*
         * Account/CreateAccount
         * Starts the process to register a new account
         */
        public ActionResult CreateAccount( ) {
            if ( Session[ "email" ] == null ) {
                String email = Request.Form[ "Email" ];
                if ( _iuser.Exist( email ) ) {
                    ViewBag.Title = "Oops!";
                    ViewBag.Comment = "Dit email adress is al in gebruik";
                } else {
                    CreateUser( email );
                    ViewBag.Title = "Gelukt!";
                    ViewBag.Comment = "Je bent geregistreerd.";
                }

                return View( );
            } else {
                return RedirectToAction( "Index", "Home" );
            }
        }

        /*
         * Account/ChangePassword
         */
        public ActionResult ChangePassword( ) {
            if ( Session[ "email" ] == null ) {
                string salt = _iuser.GetSalt( Session[ "Email" ].ToString( ) );
                var encpass = MD5Encrypt( Request.Form[ "OldPass" ], salt );
                int userId = ( int ) Session[ "userId" ];

                using ( var context = new STUFVModelContext( ) ) {
                    User user = context.Users.Single( e => e.Id == userId );
                    if ( encpass == user.PassWord ) {
                        var newpass = MD5Encrypt( Request.Form[ "NewPass" ], salt );
                        user.PassWord = newpass;
                        context.SaveChanges( );
                    } else {
                        return View( );
                    }
                }
            }

            return RedirectToAction( "Index", "Home" );
        }

        /*
         * Adds a new user to the database
         * BRAM TODO
         */
        private void CreateUser( String email ) {
            String firstName = Request.Form[ "FirstName" ];
            String lastName = Request.Form[ "LastName" ];
            String password = Request.Form[ "PassWord" ];
            DateTime birthDate = DateTime.Parse( Request.Form[ "BirthDate" ] );
            String birthPlace = Request.Form[ "BirthPlace" ];
            String sex = Request.Form[ "Sex" ];
            String street = Request.Form[ "Street" ];
            String zipCode = Request.Form[ "ZipCode" ];
            String telNr = Request.Form[ "TelNr" ];
            String mobileNr = Request.Form[ "MobileNr" ];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider( );
            String salt = GenerateRandomSalt( rng, 16 );
            String encPass = MD5Encrypt( password, salt );

            var user = new User {
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
                Email = email.ToLower( ),
                ProfilePicture = "noimageavailable.png",
                RegisterDate = DateTime.Now
            };

            using ( var context = new STUFVModelContext( ) ) {
                context.Users.Add( user );
                context.SaveChanges( );
            }

            int userId = _iuser.GetAllUsers( ).Single( e => e.Email == email ).Id;

            var settings = new ProfileSettings {
                Email = email.ToLower(),
                ProfilePicture = "noimageavailable.png"
            };
            using (var context = new STUFVModelContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
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

            using ( var context = new STUFVModelContext( ) ) {
                context.ProfileSettings.Add( settings );
                context.SaveChanges( );
            }
        }

        /*
         * Generates a random salt to add to the password
         */
        private string GenerateRandomSalt( RNGCryptoServiceProvider rng, int size ) {
            var bytes = new Byte[ size ];
            rng.GetBytes( bytes );
            return Convert.ToBase64String( bytes );
        }

        /*
         * Encrypts the password with the MD5 algorithm
         */
        private static string MD5Encrypt( string password, string salt ) {
            MD5 md5 = new MD5CryptoServiceProvider( );

            md5.ComputeHash( ASCIIEncoding.ASCII.GetBytes( salt + password ) );
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder( );
            for ( int i = 0 ; i < result.Length ; i++ ) {
                strBuilder.Append( result[ i ].ToString( "x2" ) );
            }

            return strBuilder.ToString( );
            }
        }
    }
}