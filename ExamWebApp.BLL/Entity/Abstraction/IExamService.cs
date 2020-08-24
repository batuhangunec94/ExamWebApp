using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Abstraction
{
    public interface IExamService
    {
        void Add(Exam entity);
        void Update(Exam entity);
        void Delete(Exam entity);
        Exam GetById(int Id);
        Exam GetByDefault(Expression<Func<Exam, bool>> exp);
        List<Exam> GetDefault(Expression<Func<Exam, bool>> exp);
        List<Exam> GetAll();
    }
}
