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
    public class ArticlesDetailsDTOesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArticlesDetailsDTOes
        public async Task<ActionResult> Index()
        {
            return View(await db.ArticlesDetailsDTOes.ToListAsync());
        }

        // GET: ArticlesDetailsDTOes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesDetailsDTO articlesDetailsDTO = await db.ArticlesDetailsDTOes.FindAsync(id);
            if (articlesDetailsDTO == null)
            {
                return HttpNotFound();
            }
            return View(articlesDetailsDTO);
        }

        // GET: ArticlesDetailsDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticlesDetailsDTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Content")] ArticlesDetailsDTO articlesDetailsDTO)
        {
            if (ModelState.IsValid)
            {
                db.ArticlesDetailsDTOes.Add(articlesDetailsDTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(articlesDetailsDTO);
        }

        // GET: ArticlesDetailsDTOes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesDetailsDTO articlesDetailsDTO = await db.ArticlesDetailsDTOes.FindAsync(id);
            if (articlesDetailsDTO == null)
            {
                return HttpNotFound();
            }
            return View(articlesDetailsDTO);
        }

        // POST: ArticlesDetailsDTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Content")] ArticlesDetailsDTO articlesDetailsDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articlesDetailsDTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(articlesDetailsDTO);
        }

        // GET: ArticlesDetailsDTOes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesDetailsDTO articlesDetailsDTO = await db.ArticlesDetailsDTOes.FindAsync(id);
            if (articlesDetailsDTO == null)
            {
                return HttpNotFound();
            }
            return View(articlesDetailsDTO);
        }

        // POST: ArticlesDetailsDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ArticlesDetailsDTO articlesDetailsDTO = await db.ArticlesDetailsDTOes.FindAsync(id);
            db.ArticlesDetailsDTOes.Remove(articlesDetailsDTO);
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
