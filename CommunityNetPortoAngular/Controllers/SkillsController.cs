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
    public class SkillsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Skills
        public IQueryable<Skill> GetSkills()
        {
            if (User.Identity.IsAuthenticated)
            {
                IQueryable<Skill> skills = db.Skills.Where(q => q.ResumeUser.ApplicationUser.UserName == User.Identity.Name);
                return skills;
            }
            return null;

        }

        // GET: api/Skills/5
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> GetSkill(int id)
        {
            Skill skill = await db.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        // PUT: api/Skills/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSkill( SkillViewModel skillViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (skillViewModel.ID == null)
            {
                return BadRequest();
            }
            Skill skill = new Skill { ID = skillViewModel.ID ?? 0, Name = skillViewModel.Name, Value = skillViewModel.Value };
            if (User.Identity.IsAuthenticated)
            {
                skill.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Entry(skill).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(skillViewModel.ID ?? 0))
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

        // POST: api/Skills
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> PostSkill(SkillViewModel skillViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Skill skill = new Skill { ID = skillViewModel.ID ?? 0, Name = skillViewModel.Name, Value = skillViewModel.Value };

            if (User.Identity.IsAuthenticated)
            {
                skill.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Skills.Add(skill);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = skill.ID }, skillViewModel);
        }

        // DELETE: api/Skills/5
        [ResponseType(typeof(Skill))]
        public async Task<IHttpActionResult> DeleteSkill(int id)
        {
            Skill skill = await db.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            db.Skills.Remove(skill);
            await db.SaveChangesAsync();

            return Ok(skill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillExists(int id)
        {
            return db.Skills.Count(e => e.ID == id) > 0;
        }
    }
}