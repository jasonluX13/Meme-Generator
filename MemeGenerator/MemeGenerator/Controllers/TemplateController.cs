using MemeGenerator.Data;
using MemeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeGenerator.Controllers
{
    [Authorize]
    public class TemplateController : Controller
    {
        private ITemplateRepository _templateRepo;

        public TemplateController(ITemplateRepository templateRepo)
        {
            _templateRepo = templateRepo;
        }

        // GET: Template
        public ActionResult Index()
        {
            return RedirectToAction("Templates", "Home");
        }

        //Create a new template
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateTemplate viewModel)
        {
            try
            {
                Template newTemplate = new Template()
                {
                    Title = viewModel.Title,
                    Url = viewModel.Url
                };
                _templateRepo.Insert(newTemplate);
                return RedirectToAction("Index");
            }
            catch{

            }
            return View(viewModel);
        }
    }
}