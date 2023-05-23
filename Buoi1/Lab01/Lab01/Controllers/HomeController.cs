using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.message = "Chào mừng bạn đến với ASP.NET MVC 5";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Đây là tran About";

            return View();
        }

       
    }
}