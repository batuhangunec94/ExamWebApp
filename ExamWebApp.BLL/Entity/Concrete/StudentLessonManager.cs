using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamWebApp.BLL.Entity.Concrete
{
    public class StudentLessonManager : IStudentLessonService
    {
        IStudentLessonRepository _studentLessonRepository;
        public StudentLessonManager(IStudentLessonRepository studentLessonRepository)
        {
            _studentLessonRepository = studentLessonRepository;
        }
        public void Add(StudentLesson entity)
        {
            _studentLessonRepository.Add(entity);
        }
        public List<StudentLesson> GetAll()
        {
            return _studentLessonRepository.GetAll();
        }

        public AppUser GetLessonForUser(string Id)
        {
            return GetLessonForUser(Id);
        }
    }
}
