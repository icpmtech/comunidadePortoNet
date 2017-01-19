using CommunityNetPortoAngular.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CommunityNetPortoAngular.DAL
{
    public class ArticleUserRepository : IArticleUserRepository, IDisposable
    {
        private ApplicationDbContext context;
        public  ArticleUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteArticleUser(int articleUserID)
        {
            ArticleUser ArticleUser = context.ArticlesUsers.Find(articleUserID);
            context.ArticlesUsers.Remove(ArticleUser);
        }

        public ArticleUser GetArticleUserByID(int articleUserId)
        {
            return context.ArticlesUsers.Find(articleUserId);
        }

        public IEnumerable<ArticleUser> GetArticleUsers()
        {
            return context.ArticlesUsers.ToList();
        }

        public void InsertArticleUser(ArticleUser articleUser)
        {
            context.ArticlesUsers.Add(articleUser);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateArticleUser(ArticleUser articleUser)
        {
            context.Entry(articleUser).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }



                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ArticleUserRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
        #endregion

    }
}