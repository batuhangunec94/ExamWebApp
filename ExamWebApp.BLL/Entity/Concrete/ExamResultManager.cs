using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Concrete
{
    public class ExamResultManager : IExamResultService
    {
        IExamResultRepository _examResult;
        public ExamResultManager(IExamResultRepository examResultRepository)
        {
            _examResult = examResultRepository;
        }
        public void Add(ExamResult entity)
        {
            _examResult.Add(entity);
        }

        public void Delete(ExamResult entity)
        {
            _examResult.Delete(entity);
        }

        public List<ExamResult> GetAll()
        {
            return _examResult.GetAll();
        }

        public ExamResult GetByDefault(Expression<Func<ExamResult, bool>> exp)
        {
            return _examResult.GetByDefault(exp);
        }

        public ExamResult GetById(int Id)
        {
            return _examResult.GetById(Id);
        }

        public List<ExamResult> GetDefault(Expression<Func<ExamResult, bool>> exp)
        {
            return _examResult.GetDefault(exp);
        }

        public void Update(ExamResult entity)
        {
            _examResult.Update(entity);
        }
    }
}
