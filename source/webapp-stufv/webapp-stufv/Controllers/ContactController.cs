using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace webapp_stufv.Controllers {
    public class ContactController : Controller {
        public ActionResult Index( ) {
            ViewBag.Title = "Contacteer ons bby";
            return View( );
        }

        public ActionResult SendMessage( ) {
            String name = Request.Form[ "name" ];
            String fname = Request.Form[ "firstname" ];
            String description = Request.Form[ "description" ];
            String email = Request.Form[ "email" ];
            String subject = Request.Form[ "subject" ];

            try {
                SmtpClient SmtpServer = new SmtpClient( "smtp.live.com" );
                var mail = new MailMessage( );
                mail.From = new MailAddress( "stufv.test@hotmail.com" );
                mail.To.Add( "stufv.test@hotmail.com" );
                mail.Subject = subject;
                mail.Body = description + "\nFROM: " + fname + " " + name + "\n" + "EMAIL: " + email;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential( "stufv.test@hotmail.com", "paswoord123" );
                SmtpServer.EnableSsl = true;
                SmtpServer.Send( mail );
            } catch ( Exception ex ) {
                ViewBag.Title = "Oops!";
                ViewBag.Comment = "De e-mail is niet verzonden. Probeer het later opnieuw!";
                return View( );
            }
            ViewBag.Title = "Succes!";
            ViewBag.Comment = "De e-mail is verzonden.";
            return View( );
            
        }
    }
}
