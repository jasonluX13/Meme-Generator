using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeGenerator.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        // List of completed memes
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
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