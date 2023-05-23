using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bai_3.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowMusic()
        {
            return View();
        }
        public ActionResult Download(int? MusicId,string MusicName)
        {
            ViewBag.name = MusicName;
            ViewBag.id = MusicId;
            return View();
        }
        
    }
}