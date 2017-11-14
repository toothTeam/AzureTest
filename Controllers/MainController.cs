using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SoloduhaMVC.Models;
using SoloduhaMVC.Models.Content;

namespace SoloduhaMVC.Controllers
{
    public class MainController : Controller
    {
        UserDbContext db = new UserDbContext();
        ContentDbContext dbContent = new ContentDbContext();

        public ActionResult Index()
        {
            Content c = dbContent.Contents.Where(p => p.Pagename == "main").First();
            return View(dbContent.Contents);
        }

        public ActionResult Main()
        {
            Content c = dbContent.Contents.Where(p => p.Pagename == "main").First();
            return View(c);
        }

        public ActionResult Music()
        {
            Content c;
            if (HttpContext.User.Identity.IsAuthenticated)
                c = dbContent.Contents.Where(p => p.Pagename == "music").First();
            else
                c = dbContent.Contents.Where(p => p.Pagename == "musicguest").First();

            return View(c);
        }

        public ActionResult Biography()
        {
            Content c = dbContent.Contents.Where(p => p.Pagename == "biography").First();
            return View(c);
        }

        public ActionResult Gallery()
        {
            Content c = dbContent.Contents.Where(p => p.Pagename == "gallery").First();
            return View(c);
        }
    }
}
