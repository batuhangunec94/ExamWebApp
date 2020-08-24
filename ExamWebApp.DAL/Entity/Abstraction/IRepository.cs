using ExamWebApp.Entities.Entity.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.DAL.Entity.Abstraction
{
    public interface IRepository<T>where T : class,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int Id);
        T GetByDefault(Expression<Func<T,bool>> exp);
        List<T> GetDefault(Expression<Func<T,bool>> exp);
        List<T> GetAll();

    }
}
