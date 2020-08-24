using ExamWebApp.DAL.Context;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamWebApp.DAL.Entity.Concrete
{
    public class StudentLessonRepository:IStudentLessonRepository
    {
        private ProjectContext _context;
        public StudentLessonRepository(ProjectContext context)
        {
            _context = context;
        }

        public void Add(StudentLesson entity)
        {
            _context.Add(entity);
        }

        public List<StudentLesson> GetAll()
        {
            return _context.Set<StudentLesson>().ToList();
        }

        public AppUser GetLessonForUser(string Id)
        {
            return _context.Users.Where(x => x.Id == Id).Include(x => x.StudentLessons).ThenInclude(x => x.Lesson).FirstOrDefault();
        }
    }
}
