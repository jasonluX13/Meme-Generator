using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeGenerator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // List of completed memes
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Templates()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}