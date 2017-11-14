using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoloduhaMVC.Models;
using SoloduhaMVC.Providers;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web.WebPages;
using Microsoft.Internal.Web.Utils;
using System.Web.Helpers;


namespace SoloduhaMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);

                    return RedirectToAction("Main", "Main");
                }
                else
                {
                    //ошибка неверное имя или пароль
                }
            }

            return View(model);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            if (ModelState.IsValid && !userExist(model.Login))
            {
                addUserToDb(model);
                FormsAuthentication.SetAuthCookie(model.Login, false);
                return RedirectToAction("Main", "Main");
            }
            else
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже существует");
            }
            return View(model);
        }

        bool userExist(string login)
        {
            using (UserDbContext db = new UserDbContext())
            {
                User user = (from u in db.Users where u.Login == login select u).FirstOrDefault();
                if (user != null)
                    return true;
            }

            return false;
        }

        void addUserToDb(RegistrationModel model)
        {
            using (UserDbContext db = new UserDbContext())
            {
                db.Users.Add(new User { Login = model.Login, Password = model.Password, RoleId = 2 });
                db.SaveChanges();
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Main", "Main");
        }
    }
}
