using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bai_3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
            name: "Show Music",
            url: "Bai-Hat/Danh-Sach-Bai-Hat",
            defaults: new { controller = "Music", action = "ShowMusic" }
            );
            
            routes.MapRoute(
            name: "Music",
            url: "Bai-Hat",
            defaults: new { controller = "Music", action = "ShowMusic" }
            );

            routes.MapRoute(
                name: "Download",
                url: "Bai-Hat/{MusicName}/{MusicId}",
                defaults: new { controller = "Music", action = "Download", MusicName = (string)null, MusicId = @"\d{1,4}"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
