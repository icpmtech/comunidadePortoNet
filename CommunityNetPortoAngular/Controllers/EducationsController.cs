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
    public class EducationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Educations
        public IQueryable<Education> GetEducations()
        {

            if (User.Identity.IsAuthenticated)
            {
                IQueryable<Education> educations = db.Educations.Where(q => q.ResumeUser.ApplicationUser.UserName == User.Identity.Name);
                return educations;
            }
            return null;
        }

        // GET: api/Educations/5
        [ResponseType(typeof(Education))]
        public async Task<IHttpActionResult> GetEducation(int id)
        {
            Education education = await db.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);
        }

        // PUT: api/Educations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEducation(EducationViewModel educationViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (educationViewModel.ID == null)
            {
                return BadRequest();
            }
            Education project = new Education { ID = educationViewModel.ID ?? 0, Dob = educationViewModel.Dob, StartedOn = educationViewModel.StartedOn, Description = educationViewModel.Description, Title = educationViewModel.Title};
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
                if (!EducationExists(educationViewModel.ID ?? 0))
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

        // POST: api/Educations
        [ResponseType(typeof(Education))]
        public async Task<IHttpActionResult> PostEducation(EducationViewModel educationViewModel)
        {


            Education project = new Education { ID = educationViewModel.ID ?? 0, Dob = educationViewModel.Dob, StartedOn = educationViewModel.StartedOn, Description = educationViewModel.Description, Title = educationViewModel.Title };

            if (User.Identity.IsAuthenticated)
            {
                project.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Educations.Add(project);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = project.ID }, project);
        }

        // DELETE: api/Educations/5
        [ResponseType(typeof(Education))]
        public async Task<IHttpActionResult> DeleteEducation(int id)
        {
            Education education = await db.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            db.Educations.Remove(education);
            await db.SaveChangesAsync();

            return Ok(education);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationExists(int id)
        {
            return db.Educations.Count(e => e.ID == id) > 0;
        }
    }
}