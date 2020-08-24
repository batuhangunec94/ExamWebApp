using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Concrete
{
    public class ExamManager : IExamService
    {
        IExamRepository _examRepository;
        public ExamManager(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }
        public void Add(Exam entity)
        {
            _examRepository.Add(entity);
        }

        public void Delete(Exam entity)
        {
            _examRepository.Delete(entity);
        }

        public List<Exam> GetAll()
        {
            return _examRepository.GetAll();
        }

        public Exam GetByDefault(Expression<Func<Exam, bool>> exp)
        {
            return _examRepository.GetByDefault(exp);
        }

        public Exam GetById(int Id)
        {
            return _examRepository.GetById(Id);
        }

        public List<Exam> GetDefault(Expression<Func<Exam, bool>> exp)
        {
            return _examRepository.GetDefault(exp);
        }

        public void Update(Exam entity)
        {
            _examRepository.Update(entity);
        }
    }
}
