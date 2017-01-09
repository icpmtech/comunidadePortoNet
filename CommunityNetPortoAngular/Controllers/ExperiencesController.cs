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
    public class ExperiencesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Experiences
        public IQueryable<Experience> GetExperiences()
        {
            if (User.Identity.IsAuthenticated)
            {
                IQueryable<Experience> experiences = db.Experiences.Where(q => q.ResumeUser.ApplicationUser.UserName == User.Identity.Name);
                return experiences;
            }
            return null;
        }

        // GET: api/Experiences/5
        [ResponseType(typeof(Experience))]
        public async Task<IHttpActionResult> GetExperience(int id)
        {
            Experience experience = await db.Experiences.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            return Ok(experience);

        }

        // PUT: api/Experiences/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExperience(ExperienceViewModel experienceViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (experienceViewModel.ID == null)
            {
                return BadRequest();
            }
            Experience project = new Experience { ID = experienceViewModel.ID ?? 0, Dob = experienceViewModel.Dob, StartedOn = experienceViewModel.StartedOn, Description = experienceViewModel.Description, Title = experienceViewModel.Title, TagLine = experienceViewModel.TagLine};
            if (User.Identity.IsAuthenticated)
            {
                project.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Entry(project).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(experienceViewModel.ID ?? 0))
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

        // POST: api/Experiences
        [ResponseType(typeof(Experience))]
        public async Task<IHttpActionResult> PostExperience(ExperienceViewModel experienceViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Experience project = new Experience { ID = experienceViewModel.ID ?? 0, Dob = experienceViewModel.Dob, StartedOn = experienceViewModel.StartedOn, Description = experienceViewModel.Description, Title = experienceViewModel.Title, TagLine = experienceViewModel.TagLine };

            if (User.Identity.IsAuthenticated)
            {
                project.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Experiences.Add(project);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = project.ID }, project);
        }

        // DELETE: api/Experiences/5
        [ResponseType(typeof(Experience))]
        public async Task<IHttpActionResult> DeleteExperience(int id)
        {
            Experience experience = await db.Experiences.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            db.Experiences.Remove(experience);
            await db.SaveChangesAsync();

            return Ok(experience);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExperienceExists(int id)
        {
            return db.Experiences.Count(e => e.ID == id) > 0;
        }
    }
}