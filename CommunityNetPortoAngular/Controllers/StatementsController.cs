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
   // [Authorize(Roles ="Admin")]
     [Authorize(Users ="miguelrox@msn.com")]
    public class StatementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Statements
        public async Task<ActionResult> Index()
        {
            return View(await db.Statements.ToListAsync());
        }

        // GET: Statements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statement statement = await db.Statements.FindAsync(id);
            if (statement == null)
            {
                return HttpNotFound();
            }
            return View(statement);
        }

        // GET: Statements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Description,Link,Publish,Tag,Name")] Statement statement)
        {
            if (ModelState.IsValid)
            {
                db.Statements.Add(statement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(statement);
        }

        // GET: Statements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statement statement = await db.Statements.FindAsync(id);
            if (statement == null)
            {
                return HttpNotFound();
            }
            return View(statement);
        }

        // POST: Statements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Description,Link,Publish,Tag,Name")] Statement statement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(statement);
        }

        // GET: Statements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statement statement = await db.Statements.FindAsync(id);
            if (statement == null)
            {
                return HttpNotFound();
            }
            return View(statement);
        }

        // POST: Statements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Statement statement = await db.Statements.FindAsync(id);
            db.Statements.Remove(statement);
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
