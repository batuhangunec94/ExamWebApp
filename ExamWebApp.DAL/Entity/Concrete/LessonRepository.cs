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
    public class LessonRepository:BaseRepository<Lesson>,ILessonRepository
    {
        private ProjectContext _context;
        public LessonRepository(ProjectContext context):base(context)
        {
            _context = context;
        }

        public void DeleteLessonWithQuestion(int lessonId, int questionId)
        {
            using (_context)
            {
                var tSql = @"delete from Question where Id=@p0";
                _context.Database.ExecuteSqlRaw(tSql, questionId);
            }
        }

        public Lesson GetDetailByUser(int Id)
        {
            return _context.Lessons.Where(x => x.Id == Id).Include(x => x.StudentLessons).FirstOrDefault();
        }

        public List<Lesson> GetLessonByUser(string Id)
        {
            return _context.Lessons.Include(x => x.StudentLessons.Select(x => x.AppUserId == Id)).ToList();

        }
    }
}
