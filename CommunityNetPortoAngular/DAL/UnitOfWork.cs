using CommunityNetPortoAngular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CommunityNetPortoAngular.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<ArticleUser> articleUserRepository;
        private GenericRepository<ArticleRating> articleRatingRepository;

        public GenericRepository<ArticleUser> ArticleUserRepository
        {
            get
            {

                if (this.articleUserRepository == null)
                {
                    this.articleUserRepository = new GenericRepository<ArticleUser>(context);
                }
                return articleUserRepository;
            }
        }

        public GenericRepository<ArticleRating> ArticleRatingRepository
        {
            get
            {

                if (this.articleRatingRepository == null)
                {
                    this.articleRatingRepository = new GenericRepository<ArticleRating>(context);
                }
                return articleRatingRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}