using MemeGenerator.Data;
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
        private ITemplateRepository _templateRepo;

        public HomeController(ITemplateRepository templateRepo)
        {
            _templateRepo = templateRepo;
        }
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
            List<Template> templates = _templateRepo.GetAll();
            return View(templates);
        }


        public ActionResult Create()
        {
            return View();
        }

    }
}