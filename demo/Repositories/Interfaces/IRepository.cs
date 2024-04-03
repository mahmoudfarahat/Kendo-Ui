using demo.Models;
using demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Repositories.Interfaces
{
    public interface IRepository<T, TKey> where T : class 
    {
        IReadOnlyList<T> GetAll();

        void Add(T entity);

        void Delete(TKey tkey);

        int Count();

        void Update(T entity);

        T GetByid(TKey tkey);

    }
}