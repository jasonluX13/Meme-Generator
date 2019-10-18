using MemeGenerator.Data;
using MemeGenerator.Security;
using MemeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }
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


        public ActionResult Create(CreateTemplate viewModel)
        {
            return View(viewModel);
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
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string serverPath = string.Empty;
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates"), fileName);
                file.SaveAs(path);
                serverPath = $"http://wos-meme-generator.azurewebsites.net/Templates/{fileName}";
            }
            return RedirectToAction("Create", new CreateTemplate() { Url = serverPath });
        }

        public ActionResult Remove(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!CustomUser.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Home");
            }
            Template template = _templateRepo.GetById((int)id);
            return View(template);
        }

      
    }
}