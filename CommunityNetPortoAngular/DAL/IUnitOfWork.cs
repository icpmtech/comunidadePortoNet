using CommunityNetPortoAngular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CommunityNetPortoAngular.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<CommunityNetPortoAngular.Models.ArticleUser> ArticleUserRepository { get; }
        void Commit();
    }
}