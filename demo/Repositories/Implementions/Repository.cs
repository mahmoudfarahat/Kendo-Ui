using demo.Models;
using demo.Repositories.Interfaces;
using demo.Services.Interfaces;
using demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Repositories.Implementions
{
    public class Repository<T,TKey> : IRepository<T,TKey> where T : class
    {
         private readonly ApplicationDbContext db;

        public Repository(  ApplicationDbContext db )
        {
            this.db = db;
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public int Count()
        {
            return db.Set<T>().Count();
        }

        public void Delete(TKey tkey)
        {
            var entity = db.Set<T>().Find(tkey);
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public IReadOnlyList<T> GetAll()
        {
           return db.Set<T>().ToList();

                }
    }
}