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
        private ICoordinateRepository _coordRepo;

        public TemplateController(ITemplateRepository templateRepo, ICoordinateRepository coordRepo)
        {
            _templateRepo = templateRepo;
            _coordRepo = coordRepo;
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
        public ActionResult Create(CreateTemplate viewModel, string[] coords)
        {
            try
            {
                Template newTemplate = new Template()
                {
                    Title = viewModel.Title,
                    Url = viewModel.Url
                };
                int id = _templateRepo.Insert(newTemplate);
                foreach (var coord in coords)
                {
                    var xy = coord.Split(',');
                    double x = double.Parse(xy[0]);
                    double y = double.Parse(xy[1]);
                    Coordinates coordinate = new Coordinates()
                    {
                        X = x,
                        Y = y,
                        TemplateId = id
                    };
                    _coordRepo.Insert(coordinate);                   
                }
                return RedirectToAction("Create", "Home", new { id = id });
            }
            catch{

            }
            return View(viewModel);
        }
    }
}