using CommunityNetPortoAngular.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CommunityNetPortoAngular.DAL
{
    public interface IGenericRepository<T>  where T : class
    {
        IQueryable<T> AsQueryable();

        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T GetById(int id);

        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
    }
}