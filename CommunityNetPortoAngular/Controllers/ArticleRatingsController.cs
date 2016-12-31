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
    public class ArticleRatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArticleRatings
        public async Task<ActionResult> Index()
        {
            return View(await db.ArticleRatings.ToListAsync());
        }

        // GET: ArticleRatings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleRating articleRating = await db.ArticleRatings.FindAsync(id);
            if (articleRating == null)
            {
                return HttpNotFound();
            }
            return View(articleRating);
        }

        // GET: ArticleRatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Rating,TotalRaters,AverageRating")] ArticleRating articleRating)
        {
            if (ModelState.IsValid)
            {
                db.ArticleRatings.Add(articleRating);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(articleRating);
        }

        // GET: ArticleRatings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleRating articleRating = await db.ArticleRatings.FindAsync(id);
            if (articleRating == null)
            {
                return HttpNotFound();
            }
            return View(articleRating);
        }

        // POST: ArticleRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<ActionResult> Edit([Bind(Include = "ID,Rating,TotalRaters,AverageRating,ArticleID")] ArticleRating articleRating)
        {
            if (ModelState.IsValid)
            {

                db.Entry(articleRating).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(articleRating);
        }
        // POST: ArticleRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<double> Update(int? Id, double Rating)
        {
            if (Id == null)
            {
                return 0;
            }
            ArticleUser articleRating = await db.ArticlesUsers.FindAsync(Id);

            articleRating.Total += Rating;
            articleRating.Vote += 1;
            articleRating.Rating_ = articleRating.Total / articleRating.Vote;
            Rating = articleRating.Rating_;
            if (articleRating == null)
            {
                return 0;
            }
            db.Entry(articleRating).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Rating;
        }

        // GET: ArticleRatings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleRating articleRating = await db.ArticleRatings.FindAsync(id);
            if (articleRating == null)
            {
                return HttpNotFound();
            }
            return View(articleRating);
        }

        // POST: ArticleRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ArticleRating articleRating = await db.ArticleRatings.FindAsync(id);
            db.ArticleRatings.Remove(articleRating);
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
