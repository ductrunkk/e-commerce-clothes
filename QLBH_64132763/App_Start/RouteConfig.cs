using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLBH_64132763
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
    new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product Category",
                url: "Product/{metatitle}-{ID}",
                defaults: new { controller = "Product_64132763", action = "Category", ID = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { controller = "User_64132763", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "User_64132763", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Contact_64132763", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "cart-update",
                defaults: new { controller = "Cart_64132763", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Payment",
                url: "Payment",
                defaults: new { controller = "Cart_64132763", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Add Cart",
                url: "add-cart",
                defaults: new { controller = "Cart_64132763", action = "AddItem", ID = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Payment Success",
                url: "finish",
                defaults: new { controller = "Cart_64132763", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Payment Failture",
                url: "error-payment",
                defaults: new { controller = "Cart_64132763", action = "Failture", id = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Search Product",
                url: "search",
                defaults: new { controller = "Product_64132763", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );
            routes.MapRoute(
                name: "Product Detail",
                url: "Detail/{metatitle}-{ID}",
                defaults: new { controller = "Product_64132763", action = "Detail", ID = UrlParameter.Optional},
                namespaces: new[] { "QLBH_64132763.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home_64132763", action = "Index", id = UrlParameter.Optional},
                namespaces: new[] {"QLBH_64132763.Controllers"}
            );
        }
    }
}
