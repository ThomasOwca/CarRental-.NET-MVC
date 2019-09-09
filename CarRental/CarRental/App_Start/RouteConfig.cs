using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarRental
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{searchValue}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, searchValue = "" }
            );

            //routes.MapRoute(
            //    name: "Search",
            //    url: "{controller}/{action}/{search}",
            //    defaults: new { controller = "CarRental", action = "Index", search = UrlParameter.Optional }
            //);
        }
    }
}
