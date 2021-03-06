﻿using System;
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
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Projects
        public IQueryable<Project> GetProjects()
        {
            if (User.Identity.IsAuthenticated)
            {
                IQueryable<Project> projects= db.Projects.Where(q => q.ResumeUser.ApplicationUser.UserName == User.Identity.Name);
                return projects;
            }
            return null;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> GetProject(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProject( ProjectViewModel projectViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ( projectViewModel.ID==null)
            {
                return BadRequest();
            }
            Project project = new Project { ID = projectViewModel.ID ?? 0, Name = projectViewModel.Name, Title = projectViewModel.Title, Link = projectViewModel.Link };
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
                if (!ProjectExists(projectViewModel.ID??0))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> PostProject(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Project project = new Project { ID = projectViewModel.ID ?? 0, Name = projectViewModel.Name, Title = projectViewModel.Title, Link = projectViewModel.Link };

            if (User.Identity.IsAuthenticated)
            {
                project.ResumeUser = db.Resumes.Where(s => s.ApplicationUser.UserName == User.Identity.Name).FirstOrDefault();
            }
            db.Projects.Add(project);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = project.ID }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> DeleteProject(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            await db.SaveChangesAsync();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.ID == id) > 0;
        }
    }
}