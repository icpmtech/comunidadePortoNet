using CommunityNetPortoAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityNetPortoAngular.DAL
{
    public interface IArticleUserRepository : IDisposable
    {
        IEnumerable<ArticleUser> GetArticleUsers();
        ArticleUser GetArticleUserByID(int articleUserId);
        void InsertArticleUser(ArticleUser articleUser);
        void DeleteArticleUser(int articleUserID);
        void UpdateArticleUser(ArticleUser articleUser);
        void Save();
    }
}