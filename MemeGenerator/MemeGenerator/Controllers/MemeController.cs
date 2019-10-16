using MemeGenerator.Data;
using MemeGenerator.Security;
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
        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }


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

        [AllowAnonymous]
        async public Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            MemeResponse meme  = await _memeRepo.GetMemeAsync((int)id);
            if (meme == null)
            {
                return RedirectToAction("Index", "Home");
            }
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

        [AllowAnonymous]
        async public Task<ActionResult> Random()
        {
            int total = _memeRepo.Count();
            Random r = new Random();
            int offset = r.Next(1, total);
            MemeResponse meme = await _memeRepo.GetMemeAsync(offset);
            //return RedirectToAction("Details", new { id = offset });
            return View(meme);
        }

        async public Task<ActionResult> RemoveComment(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!CustomUser.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Home");
            }

            Comment comment = await _memeRepo.GetCommentById((int)id);
            if (comment == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(comment);
        }

        [ValidateAntiForgeryToken, HttpPost]
        async public Task<ActionResult> RemoveComment(Comment comment)
        {
            if (!CustomUser.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                comment.Text = "[Removed]";
                _memeRepo.RemoveCommentAsync(comment);
                return RedirectToAction("Details", new { id = comment.MemeId });
            }
            catch
            {

            }
            return RedirectToAction("Index", "Home");
        }

        async public Task<ActionResult> RemoveMeme(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!CustomUser.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Home");
            }
            MemeResponse meme = await _memeRepo.GetMemeAsync((int)id);
            return View(meme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> RemoveMeme(MemeResponse viewModel)
        {
            if (!CustomUser.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                Meme meme = _memeRepo.GetMemeById(viewModel.Id);
                _memeRepo.RemoveMeme(meme);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                
            }
            return View(viewModel);
        }


    }
}