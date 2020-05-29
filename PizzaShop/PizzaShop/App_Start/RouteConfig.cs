using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PizzaShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Them Mon",
                url: "them-gio-hang",
                defaults: new { controller = "CartShop", action = "addToCart", id = UrlParameter.Optional },
                namespaces: new[] { "PizzaShop.Controllers" }
            );

            routes.MapRoute(
                name: "CartShop",
                url: "cap-nhap-gio-hang",
                defaults: new { controller = "CartShop", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PizzaShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PizzaShop.Controllers" }
            );
        }
    }
}
