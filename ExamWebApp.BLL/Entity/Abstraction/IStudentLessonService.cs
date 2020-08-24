using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Abstraction
{
    public interface IStudentLessonService
    {
        void Add(StudentLesson entity);
        List<StudentLesson> GetAll();
        AppUser GetLessonForUser(string Id);
    }
}
