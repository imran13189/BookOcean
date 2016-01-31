using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookOcean.Repository.Abstract;
using BookOcean.Domain.Entities;

namespace BookOcean.Web.Controllers
{
    public class AccountController : Controller
    {
        IUser _user;
        public AccountController(IUser user)
        {
            _user = user;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(_user.IsUserExist(model))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "User doesn't exist";
            return View();

        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            _user.Register(model);
            return View();
        }
    }
}