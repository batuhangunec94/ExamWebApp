using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Abstraction
{
    public interface ILessonService
    {
        void Add(Lesson entity);
        void Update(Lesson entity);
        void Delete(Lesson entity);
        Lesson GetById(int Id);
        Lesson GetByDefault(Expression<Func<Lesson, bool>> exp);
        List<Lesson> GetDefault(Expression<Func<Lesson, bool>> exp);
        List<Lesson> GetAll();
        void DeleteLessonWithQuestion(int lessonId, int questionId);
        Lesson GetDetailByUser(int Id);
        List<Lesson> GetLessonByUser(string Id);
    }
}
