using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Abstraction
{
    public interface IExamResultService
    {
        void Add(ExamResult entity);
        void Update(ExamResult entity);
        void Delete(ExamResult entity);
        ExamResult GetById(int Id);
        ExamResult GetByDefault(Expression<Func<ExamResult, bool>> exp);
        List<ExamResult> GetDefault(Expression<Func<ExamResult, bool>> exp);
        List<ExamResult> GetAll();
    }
}
