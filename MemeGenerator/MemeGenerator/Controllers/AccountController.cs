using MemeGenerator.Data;
using MemeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MemeGenerator.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepo;

        public AccountController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        // GET: Account
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView viewModel)
        {
            //TODO handle login
            User user = _userRepo.GetByUsername(viewModel.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(viewModel);
            }
            if (BCrypt.Net.BCrypt.Verify(viewModel.Password, user.HashedPassword))
            {
                FormsAuthentication.SetAuthCookie(viewModel.Username, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email or password is incorrect");
            return View(viewModel);
        }

        public ActionResult Register()
        {
            //TODO Register user
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            //TODO Logout user
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}