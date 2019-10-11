using MemeGenerator.Data;
using MemeGenerator.Repositories;
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
        private IUserRepository _userRepo;
        private IMemeRepository _memeRepo;
        private IMemeCoordinateRepository _memeCoordsRepo;

        public HomeController(ITemplateRepository templateRepo, IUserRepository userRepo, IMemeRepository memeRepo, IMemeCoordinateRepository memeCoordsRepo)
        {
            _templateRepo = templateRepo;
            _userRepo = userRepo;
            _memeRepo = memeRepo;
            _memeCoordsRepo = memeCoordsRepo;
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


        public ActionResult Create(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            Template template = _templateRepo.GetById((int)id);
            
            return View(template);
        }

        [HttpPost]
        public ActionResult Create(Template template, string[] textData)
        {

            int templateId = template.Id;
            string title = template.Title;

            try
            {
                template = _templateRepo.GetById(templateId);
                User currentUser = _userRepo.GetByUsername(User.Identity.Name);
                List<MemeCoordinates> memeCoords = new List<MemeCoordinates>();

                Meme meme = new Meme()
                {
                    Title = title,
                    Url = template.Url,
                    CreatorId = currentUser.Id,

                };
                int memeId = _memeRepo.AddMeme(meme);
                for (int i = 0; i < template.Coordinates.Count; i++)
                {
                    MemeCoordinates mCoord = new MemeCoordinates()
                    {
                        X = template.Coordinates[i].X,
                        Y = template.Coordinates[i].Y,
                        Text = textData[i],
                        MemeId = memeId
                    };
                    _memeCoordsRepo.Insert(mCoord);
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {

            }

            return RedirectToAction("Create", new { id = templateId });
        }

    }
}