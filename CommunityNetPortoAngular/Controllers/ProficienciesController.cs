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
    public class ProficienciesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Proficiencies
        public IQueryable<Proficiency> GetProficiencies()
        {
            if (User.Identity.IsAuthenticated)
            {
                IQueryable<Proficiency> Proficiencies = db.Proficiencies.Where(q => q.ResumeUser.ApplicationUser.UserName == User.Identity.Name);
                return Proficiencies;
            }
            return null;

        }

        // GET: api/Proficiencies/5
        [ResponseType(typeof(Proficiency))]
        public async Task<IHttpActionResult> GetProficiency(int id)
        {
            Proficiency proficiency = await db.Proficiencies.FindAsync(id);
            if (proficiency == null)
            {
                return NotFound();
            }

            return Ok(proficiency);
        }

        // PUT: api/Proficiencies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProficiency(int id, Proficiency proficiency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proficiency.ID)
            {
                return BadRequest();
            }

            db.Entry(proficiency).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProficiencyExists(id))
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

        // POST: api/Proficiencies
        [ResponseType(typeof(Proficiency))]
        public async Task<IHttpActionResult> PostProficiency(Proficiency proficiency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proficiencies.Add(proficiency);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = proficiency.ID }, proficiency);
        }

        // DELETE: api/Proficiencies/5
        [ResponseType(typeof(Proficiency))]
        public async Task<IHttpActionResult> DeleteProficiency(int id)
        {
            Proficiency proficiency = await db.Proficiencies.FindAsync(id);
            if (proficiency == null)
            {
                return NotFound();
            }

            db.Proficiencies.Remove(proficiency);
            await db.SaveChangesAsync();

            return Ok(proficiency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProficiencyExists(int id)
        {
            return db.Proficiencies.Count(e => e.ID == id) > 0;
        }
    }
}