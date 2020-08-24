using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Concrete
{
    public class QuestionsManager : IQuestionsService
    {
        private IQuestionsRepository _questions;
        public QuestionsManager(IQuestionsRepository questionsRepository)
        {
            _questions = questionsRepository;
        }
        public void Add(Questions entity)
        {
            _questions.Add(entity);
        }

        public void Delete(Questions entity)
        {
            _questions.Delete(entity);
        }

        public List<Questions> GetAll()
        {
            return _questions.GetAll();
        }

        public List<Questions> GetAllByLessonId(int Id)
        {
            return _questions.GetAllByLessonId(Id);
        }

        public Questions GetByDefault(Expression<Func<Questions, bool>> exp)
        {
            return _questions.GetByDefault(exp);
        }

        public Questions GetById(int Id)
        {
            return _questions.GetById(Id);
        }

        public List<Questions> GetDefault(Expression<Func<Questions, bool>> exp)
        {
            return _questions.GetDefault(exp);
        }

        public void Update(Questions entity)
        {
            _questions.Update(entity);
        }
    }
}
