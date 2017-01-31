using CommunityNetPortoAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunityNetPortoAngular.Controllers
{
    [Authorize]
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [AllowAnonymous]

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult NumberOfUsers()
        {

            return PartialView(new NumberUserViewModel { Value = db.ArticlesUsers.Where(q => q.Publish == true).Count()+1 });
        }
        [AllowAnonymous]
        public PartialViewResult NumberOfEvents()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult NumberOfArticles()
        {
            return PartialView(new NumberArticlesViewModel { Value = db.Users.Count()+1 });
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult _TopArticles()
        {

                return View( db.ArticlesUsers.Include("ApplicationUser").Where(q=>q.Publish==true).OrderBy(s => s.Rating ).Take(10).ToList());



        }
        [AllowAnonymous]
        public ActionResult _Articles()
        {

            return View(db.ArticlesUsers.Include("ApplicationUser").Where(q => q.Publish == true).OrderBy(s => s.Rating).ToList());



        }
        [AllowAnonymous]
        public ActionResult _Offers()
        {

            return View(db.Offers.Include("ResumeUser").Where(q => q.Active == true).ToList());



        }
        [AllowAnonymous]
        public ActionResult _Statements()
        {

            return View(db.Statements.Include("ResumeUser").Where(q => q.Publish == true).ToList());



        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}