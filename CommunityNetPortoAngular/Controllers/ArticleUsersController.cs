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
    public class ArticleUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArticleUsers
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
                return View(await db.ArticlesUsers.Where(s => s.ApplicationUser.UserName == User.Identity.Name).ToListAsync());
            else
                return View();
        }

        // GET: ArticleUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleUser articleUser = await db.ArticlesUsers.Include("ApplicationUser").SingleOrDefaultAsync(i => i.ID == id); ;
            if (articleUser == null)
            {
                return HttpNotFound();
            }
            return View(articleUser);
        }

        // GET: ArticleUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Title,ImageUrl,Header,Footer,Summary,Content")] ArticleUser articleUser)
        {
            if (ModelState.IsValid)
            {
               var user= db.Users.First(s => s.UserName == User.Identity.Name);
                articleUser.ApplicationUser = user;
                articleUser.CreationDate_=DateTime.Now;
                db.ArticlesUsers.Add(articleUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(articleUser);
        }

        // GET: ArticleUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleUser articleUser = await db.ArticlesUsers.FindAsync(id);
            if (articleUser == null)
            {
                return HttpNotFound();
            }
            return View(articleUser);
        }

        // POST: ArticleUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Title,ImageUrl,Header,Footer,Summary,Content")] ArticleUser articleUser)
        {
            if (ModelState.IsValid)
            {

                db.Entry(articleUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(articleUser);
        }

        // GET: ArticleUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleUser articleUser = await db.ArticlesUsers.FindAsync(id);
            if (articleUser == null)
            {
                return HttpNotFound();
            }
            return View(articleUser);
        }

        // POST: ArticleUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ArticleUser articleUser = await db.ArticlesUsers.FindAsync(id);
            db.ArticlesUsers.Remove(articleUser);
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
