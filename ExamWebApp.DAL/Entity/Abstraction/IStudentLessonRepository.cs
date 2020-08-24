using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.DAL.Entity.Abstraction
{
    public interface IStudentLessonRepository
    {
        void Add(StudentLesson entity);
        List<StudentLesson> GetAll();
        AppUser GetLessonForUser(string Id);
    }
}
