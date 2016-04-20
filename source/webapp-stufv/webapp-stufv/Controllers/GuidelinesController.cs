using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp_stufv.Models;

namespace webapp_stufv.Controllers {
    public class GuidelinesController : Controller {
        // GET: Guidelines
        public ActionResult Index ( ) {
            Guideline gl = new Guideline ( );
            gl.Id = 1;
            gl.Content = "Circus strongman dickie davies groomed cappuccino catcher challenge you to a duel crumb catcher john aldridge et sodales cum, crumb catcher Semi beard dickie davies john aldridge et sodales cum challenge you to a duel circus strongman marquess of queensbury groomed cappuccino catcher socially mobile, marquess of queensbury john aldridge mexican’t circus strongman challenge you to a duel iron tache et sodales cum Semi beard socially mobile stiff upper lip lemmy cappuccino catcher crumb catcher dickie davies groomed. John aldridge furry facial friend dick van dyke fox hunting French café patron musketeer? Hair trimmer d’artagnan marquess of queensbury freestyle. Helllloooo tudor philosopher graeme souness leader of men, graeme souness challenge you to a duel super mario leader of men charity donate tudor philosopher hello, we’re cockneys tricky sneezes dick dastardly helllloooo? Felis nefarious brandy tom selleck, cappuccino collector tom selleck nefarious brandy challenge you to a duel felis old west sheriff professor plum lip warmer. Marquess of queensbury charming villain frontiersman karl marx hulk hogan, frontiersman charming villain louis xiii karl marx gentleman marquess of queensbury frontiersman hulk hogan, charming villain karl marx socially mobile frontiersman gentleman toothbrush frontiersman waiter louis xiii lorreto del mar frightfully nice hulk hogan marquess of queensbury soup strainer.Lady magnets beefeater devilish cad brush, lady magnets dodgy uncle clive brush charming villain beefeater cardinal richelieu 118 118 devilish cad Milkshake issues cunning like a fox boxing champion, cunning like a fox tony stark dick van dyke zap rowsdower country baron alpha trion stache tricky sneezes lady magnets Milkshake issues devilish cad dodgy uncle clive brush cardinal richelieu boxing champion landed gentry beefeater 118 118 charming villain.";
            Guideline gl_2 = new Guideline ( );
            gl.Id = 2;
            gl.Content = "Circus strongman dickie davies groomed cappuccino catcher challenge you to a duel crumb catcher john aldridge et sodales cum, crumb catcher Semi beard dickie davies john aldridge et sodales cum challenge you to a duel circus strongman marquess of queensbury groomed cappuccino catcher socially mobile, marquess of queensbury john aldridge mexican’t circus strongman challenge you to a duel iron tache et sodales cum Semi beard socially mobile stiff upper lip lemmy cappuccino catcher crumb catcher dickie davies groomed. John aldridge furry facial friend dick van dyke fox hunting French café patron musketeer? Hair trimmer d’artagnan marquess of queensbury freestyle. Helllloooo tudor philosopher graeme souness leader of men, graeme souness challenge you to a duel super mario leader of men charity donate tudor philosopher hello, we’re cockneys tricky sneezes dick dastardly helllloooo? Felis nefarious brandy tom selleck, cappuccino collector tom selleck nefarious brandy challenge you to a duel felis old west sheriff professor plum lip warmer. Marquess of queensbury charming villain frontiersman karl marx hulk hogan, frontiersman charming villain louis xiii karl marx gentleman marquess of queensbury frontiersman hulk hogan, charming villain karl marx socially mobile frontiersman gentleman toothbrush frontiersman waiter louis xiii lorreto del mar frightfully nice hulk hogan marquess of queensbury soup strainer.Lady magnets beefeater devilish cad brush, lady magnets dodgy uncle clive brush charming villain beefeater cardinal richelieu 118 118 devilish cad Milkshake issues cunning like a fox boxing champion, cunning like a fox tony stark dick van dyke zap rowsdower country baron alpha trion stache tricky sneezes lady magnets Milkshake issues devilish cad dodgy uncle clive brush cardinal richelieu boxing champion landed gentry beefeater 118 118 charming villain.";

            List<Guideline> _gls = new List<Guideline> ( );
            _gls.Add ( gl );
            _gls.Add ( gl_2 );
            return View ( _gls );
        }
    }
}