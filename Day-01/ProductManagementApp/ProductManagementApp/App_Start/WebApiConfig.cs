using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductManagementApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(name: "Custom", routeTemplate: "api/{controller}/Search",

                defaults: new { controller = "Products", action = "Search"});
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
