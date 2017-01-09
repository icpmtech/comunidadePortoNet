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
    public class LanguagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Languages
        public IQueryable<Language> GetLanguages()
        {

            if (User.Identity.IsAuthenticated)
            {
                IQueryable<Language> languages = db.Languages.Where(q => q.ResumeUser.ApplicationUser.UserName == User.Identity.Name);
                return languages;
            }
            return null;
        }

        // GET: api/Languages/5
        [ResponseType(typeof(Language))]
        public async Task<IHttpActionResult> GetLanguage(int id)
        {
            Language language = await db.Languages.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        // PUT: api/Languages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLanguage(LanguageViewModel languageViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (languageViewModel.ID == null)
            {
                return BadRequest();
            }
            Language language = new Language { ID = languageViewModel.ID ?? 0, Description = languageViewModel.Description, Value = languageViewModel.Value };
            if (User.Identity.IsAuthenticated)
            {
                language.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Entry(language).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(languageViewModel.ID ?? 0))
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

        // POST: api/Languages
        [ResponseType(typeof(Language))]
        public async Task<IHttpActionResult> PostLanguage(LanguageViewModel languageViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Language language = new Language { ID = languageViewModel.ID ?? 0, Description = languageViewModel.Description, Value = languageViewModel.Value };

            if (User.Identity.IsAuthenticated)
            {
                language.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Languages.Add(language);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = language.ID }, languageViewModel);
        }

        // DELETE: api/Languages/5
        [ResponseType(typeof(Language))]
        public async Task<IHttpActionResult> DeleteLanguage(int id)
        {
            Language language = await db.Languages.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }

            db.Languages.Remove(language);
            await db.SaveChangesAsync();

            return Ok(language);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LanguageExists(int id)
        {
            return db.Languages.Count(e => e.ID == id) > 0;
        }
    }
}