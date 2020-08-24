using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Concrete
{
    public class LessonManager : ILessonService
    {
        private ILessonRepository _lesson;
        public LessonManager(ILessonRepository lessonRepository)
        {
            _lesson = lessonRepository;
        }
        public void Add(Lesson entity)
        {
            _lesson.Add(entity);
        }

        public void Delete(Lesson entity)
        {
            _lesson.Delete(entity);
        }

        public void DeleteLessonWithQuestion(int lessonId, int questionId)
        {
            _lesson.DeleteLessonWithQuestion(lessonId,questionId);
        }

        public List<Lesson> GetAll()
        {
            return _lesson.GetAll();
        }

        public Lesson GetByDefault(Expression<Func<Lesson, bool>> exp)
        {
            return _lesson.GetByDefault(exp);
        }

        public Lesson GetById(int Id)
        {
            return _lesson.GetById(Id);
        }

        public List<Lesson> GetDefault(Expression<Func<Lesson, bool>> exp)
        {
            return _lesson.GetDefault(exp);
        }

        public Lesson GetDetailByUser(int Id)
        {
            return _lesson.GetDetailByUser(Id);
        }

        public List<Lesson> GetLessonByUser(string Id)
        {
            return _lesson.GetLessonByUser(Id);
        }

        public void Update(Lesson entity)
        {
            _lesson.Update(entity);
        }
    }
}
