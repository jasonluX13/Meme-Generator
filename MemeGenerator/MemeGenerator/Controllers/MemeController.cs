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
        private IUserRepository _userRepo;
        public MemeController(IMemeRepository memeRepo, IUserRepository userRepo)
        {
            _memeRepo = memeRepo;
            _userRepo = userRepo;
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

        public ActionResult Comment(int id)
        {
            Comment comment = new Comment();
            return View("Comment", comment);
        }

        [ValidateAntiForgeryToken, HttpPost]
        async public Task<ActionResult> Comment(int id, [Bind(Include = "Id, Text, Rating, CreatorId")] Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Text))
            {
                ModelState.AddModelError("", "Text can't be empty");
            }
            if (ModelState.IsValid)
            {
                User creator = _userRepo.GetByUsername(User.Identity.Name);

                Comment newComment = new Comment()
                {
                    CreatorId = creator.Id,
                    MemeId = id,
                    Text = comment.Text,
                };
                await _memeRepo.AddCommentAsync(newComment);
                return RedirectToAction("Details", new { id = id });
            }
            return View("Comment");
        }

    }
}