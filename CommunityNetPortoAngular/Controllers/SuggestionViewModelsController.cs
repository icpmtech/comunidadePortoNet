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
    public class SuggestionViewModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SuggestionViewModels
        public IQueryable<SuggestionViewModel> GetSuggestions()
        {
            return db.Suggestions;
        }

        // GET: api/SuggestionViewModels/5
        [ResponseType(typeof(SuggestionViewModel))]
        public async Task<IHttpActionResult> GetSuggestionViewModel(int id)
        {
            SuggestionViewModel suggestionViewModel = await db.Suggestions.FindAsync(id);
            if (suggestionViewModel == null)
            {
                return NotFound();
            }

            return Ok(suggestionViewModel);
        }

        // PUT: api/SuggestionViewModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSuggestionViewModel(int id, SuggestionViewModel suggestionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suggestionViewModel.ID)
            {
                return BadRequest();
            }

            db.Entry(suggestionViewModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuggestionViewModelExists(id))
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

        // POST: api/SuggestionViewModels
        [ResponseType(typeof(SuggestionViewModel))]
        public async Task<IHttpActionResult> PostSuggestionViewModel(SuggestionViewModel suggestionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suggestions.Add(suggestionViewModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = suggestionViewModel.ID }, suggestionViewModel);
        }

        // DELETE: api/SuggestionViewModels/5
        [ResponseType(typeof(SuggestionViewModel))]
        public async Task<IHttpActionResult> DeleteSuggestionViewModel(int id)
        {
            SuggestionViewModel suggestionViewModel = await db.Suggestions.FindAsync(id);
            if (suggestionViewModel == null)
            {
                return NotFound();
            }

            db.Suggestions.Remove(suggestionViewModel);
            await db.SaveChangesAsync();

            return Ok(suggestionViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuggestionViewModelExists(int id)
        {
            return db.Suggestions.Count(e => e.ID == id) > 0;
        }
    }
}