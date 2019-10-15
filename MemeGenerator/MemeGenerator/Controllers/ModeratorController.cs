using MemeGenerator.Data;
using MemeGenerator.Security;
using MemeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeGenerator.Controllers
{
    [Authorize]
    public class ModeratorController : Controller
    {
        private IUserRepository _userRepo;
        public CustomPrincipal CustomUser
        {
            get
            {
                return (CustomPrincipal)User;
            }
        }

        public ModeratorController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: Moderator
        public ActionResult Index()
        {
            if (!CustomUser.IsInRole("Moderator")){
                return RedirectToAction("Index", "Home");
            }

            List<User> mods = _userRepo.GetByRoleName("Moderator");
            return View(mods);
        }

        public ActionResult Add()
        {
            if (!CustomUser.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Home");
            }
            List<User> users = _userRepo.GetNormalUsers();
            return View(users);
        }

        public ActionResult Select(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!CustomUser.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Home");
            }
            User user = _userRepo.GetById((int)id);
            AddMod viewModel = new AddMod()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username
            };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Select(AddMod viewModel)
        {
            if (!CustomUser.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                UserRole newRole = new UserRole()
                {
                    RoleName = "Moderator",
                    UserId = viewModel.Id
                };
                _userRepo.AddRole(newRole);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Error, unable to add moderator");
            }       
            return View(viewModel);
        }
    }
}