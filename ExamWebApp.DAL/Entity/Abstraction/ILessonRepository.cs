using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.DAL.Entity.Abstraction
{
    public interface ILessonRepository:IRepository<Lesson>
    {
        void DeleteLessonWithQuestion(int lessonId, int questionId);
        Lesson GetDetailByUser(int Id);
        List<Lesson> GetLessonByUser(string Id);
    }
}
