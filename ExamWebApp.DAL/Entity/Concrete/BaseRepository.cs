using ExamWebApp.DAL.Context;
using ExamWebApp.DAL.Entity.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.DAL.Entity.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private ProjectContext _context;
        public BaseRepository(ProjectContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T,bool>> exp)
        {
            return _context.Set<T>().FirstOrDefault(exp);
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public List<T> GetDefault(Expression<Func<T,bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            var update = _context.Entry(entity);
            update.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
