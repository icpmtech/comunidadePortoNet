using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CommunityNetPortoAngular.Models;

namespace CommunityNetPortoAngular.Controllers
{
    public class InterestsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Interests
        public IQueryable<Interest> GetInterests()
        {
            if (User.Identity.IsAuthenticated)
            {
                IQueryable<Interest> interests = db.Interests.Where(q => q.ResumeUser.ApplicationUser.UserName == User.Identity.Name);
                return interests;
            }
            return null;
        }

        // GET: api/Interests/5
        [ResponseType(typeof(Interest))]
        public async Task<IHttpActionResult> GetInterest(int id)
        {
            Interest interest = await db.Interests.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }

            return Ok(interest);
        }

        // PUT: api/Interests/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInterest(InterestViewModel interestViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (interestViewModel.ID == null)
            {
                return BadRequest();
            }
            Interest interest = new Interest { ID = interestViewModel.ID ?? 0, Description = interestViewModel.Description };
            if (User.Identity.IsAuthenticated)
            {
                interest.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Entry(interest).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(interestViewModel.ID ?? 0))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Interests
        [ResponseType(typeof(Interest))]
        public async Task<IHttpActionResult> PostInterest(InterestViewModel interestViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Interest interest = new Interest { ID = interestViewModel.ID ?? 0, Description = interestViewModel.Description };

            if (User.Identity.IsAuthenticated)
            {
                interest.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Interests.Add(interest);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = interest.ID }, interest);
        }

        // DELETE: api/Interests/5
        [ResponseType(typeof(Interest))]
        public async Task<IHttpActionResult> DeleteInterest(int id)
        {
            Interest interest = await db.Interests.FindAsync(id);
            if (interest == null)
            {
                return NotFound();
            }

            db.Interests.Remove(interest);
            await db.SaveChangesAsync();

            return Ok(interest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InterestExists(int id)
        {
            return db.Interests.Count(e => e.ID == id) > 0;
        }
    }
}