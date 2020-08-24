using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Abstraction
{
    public interface IQuestionsService
    {
        void Add(Questions entity);
        void Update(Questions entity);
        void Delete(Questions entity);
        Questions GetById(int Id);
        Questions GetByDefault(Expression<Func<Questions, bool>> exp);
        List<Questions> GetDefault(Expression<Func<Questions, bool>> exp);
        List<Questions> GetAll();
        List<Questions> GetAllByLessonId(int Id);
    }
}
