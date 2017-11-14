using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SoloduhaMVC.Models.Content;
using SoloduhaMVC.Providers;
using SoloduhaMVC.Models;
using System.Web.Security;

namespace SoloduhaMVC.Controllers
{
    [ValidateInput(false)]
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        ContentDbContext db = new ContentDbContext();
        UserDbContext dbUsers = new UserDbContext();
        
        public ActionResult ShowPages()
        {
            return View(db.Contents);
        }

        public ActionResult EditPage(int pageid)
        {
                Content c = db.Contents.Where(p => p.Id == pageid).First();

                return View(c);
        }

        [HttpPost]
        public ActionResult EditPage(int pageid, string Information)
        {
            var content = (from p in db.Contents where p.Id == pageid select p).First();
            content.Information = Information;
            db.SaveChanges();

            return View();
        }

        public ActionResult ShowUsers()
        {
            return View(dbUsers.Users);
        }

        public ActionResult EditUser(int userid)
        {
            User u = dbUsers.Users.Where(p => p.Id == userid).First();
            return View(u);
        }

        [HttpPost]
        public ActionResult EditUser(int userid, string Login,  string Password)
        {
            var user = (from u in dbUsers.Users where u.Id == userid select u).FirstOrDefault();
            user.Login = Login;
            user.Password = Password;
            dbUsers.SaveChanges();

            return RedirectToAction("ShowUsers");
        }

        public ActionResult Menu() 
        {
            return View();
        }

        public ActionResult DeleteUser(int userid)
        {
            var user = (from u in dbUsers.Users where u.Id == userid select u).FirstOrDefault();

            if (user != null)
            {
                dbUsers.Users.Remove(user);
                dbUsers.SaveChanges();
            }

            return RedirectToAction("showusers");
        }
    }
}
