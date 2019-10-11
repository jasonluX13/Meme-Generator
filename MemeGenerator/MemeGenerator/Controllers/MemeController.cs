using MemeGenerator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MemeGenerator.Controllers
{
    [Authorize]
    public class MemeController : Controller
    {
        private IMemeRepository _memeRepo;
        public MemeController(IMemeRepository memeRepo)
        {
            _memeRepo = memeRepo;
        }

        // GET: Meme
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        async public Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            MemeResponse meme  = await _memeRepo.GetMemeAsync((int)id);
            return View(meme);
        }

    }
}