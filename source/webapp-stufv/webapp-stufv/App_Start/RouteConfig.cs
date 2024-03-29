﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webapp_stufv {
    public class RouteConfig {
        public static void RegisterRoutes ( RouteCollection routes ) {
            routes.IgnoreRoute ( "{resource}.axd/{*pathInfo}" );
            routes.MapRoute(
                name: "Contact",
                url: "Contact/{action}/{id}",
                defaults: new { controller = "Contact", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute (
                name: "Article",
                url: "News/Details/{id}",
                defaults: new { controller = "News", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute (
                name: "Emergency",
                url: "Emergency/{action}/{id}",
                defaults: new { controller = "Emergency", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
            routes.MapRoute(
                name: "FAQ",
                url: "FAQ/{action}/{id}",
                defaults: new { controller = "FAQ", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url: "Account/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Guidelines",
                url: "Guidelines/{action}",
                defaults: new { controller = "Guidelines", action = "Index"}
            );
            routes.MapRoute(
                name: "Events",
                url: "Events/{action}/{id}",
                defaults: new { controller = "Events", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Settings",
                url: "Settings/{action}/{id}",
                defaults: new { controller = "Settings", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Profile",
                url: "Profile/{action}/{id}",
                defaults: new { controller = "Profile", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Instagram",
                url: "Instagram/{action}/{id}",
                defaults: new { controller = "Instagram", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Partner",
                url: "Partner/{action}/{id}",
                defaults: new { controller = "Partner", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute (
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
