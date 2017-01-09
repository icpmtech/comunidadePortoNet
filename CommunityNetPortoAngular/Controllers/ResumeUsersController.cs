using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunityNetPortoAngular.Models;

namespace CommunityNetPortoAngular.Controllers
{
    [Authorize]
    public class ResumeUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResumeUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.Resumes.Include("Skills").Include("Experiences").Include("Educations").Include("Proficiencies").Include("Languages").Include("Interests").Include("Projects").ToListAsync());
        }

        // GET: ResumeUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeUser resumeUser = await db.Resumes.FindAsync(id);
            if (resumeUser == null)
            {
                return HttpNotFound();
            }
            return View(resumeUser);
        }
        // GET: ResumeUsers/MyProfile
        public async Task<ActionResult> MyProfile()
        {
            if (User.Identity.IsAuthenticated)

                return View(await db.Resumes.Include("ApplicationUser").Include("Experiences").Include("Educations").Include("Skills").Include("Proficiencies").Include("Languages").Include("Interests").Include("Projects").Where(s => s.ApplicationUser.UserName == User.Identity.Name).SingleOrDefaultAsync());
            else
                return View();

        }

        // GET: ResumeUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResumeUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,ImageURL,CareerProfile,Phone,GitHub,Linkedin,Twitter,PortfolioSite,TagLine")] ResumeUser resumeUser)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.First(s => s.UserName == User.Identity.Name);
                resumeUser.ApplicationUser = user;
                db.Resumes.Add(resumeUser);
                await db.SaveChangesAsync();
                return RedirectToAction("MyProfile");
            }

            return View(resumeUser);
        }

        // GET: ResumeUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ResumeUser resumeUser = await db.Resumes.Include("ApplicationUser").SingleOrDefaultAsync(i => i.ID == id); ;

            if (resumeUser == null)
            {
                return HttpNotFound();
            }
            return View(resumeUser);
        }

        // POST: ResumeUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,ImageURL,CareerProfile,Phone,GitHub,Linkedin,Twitter,PortfolioSite,TagLine")] ResumeUser resumeUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumeUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("MyProfile");
            }
            return View(resumeUser);
        }

        // GET: ResumeUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumeUser resumeUser = await db.Resumes.FindAsync(id);
            if (resumeUser == null)
            {
                return HttpNotFound();
            }
            return View(resumeUser);
        }

        // POST: ResumeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ResumeUser resumeUser = await db.Resumes.FindAsync(id);
            db.Resumes.Remove(resumeUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
