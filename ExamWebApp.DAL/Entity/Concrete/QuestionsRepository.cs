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
    public class QuestionsRepository:BaseRepository<Questions>,IQuestionsRepository
    {
        private ProjectContext _context;
        public QuestionsRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        public List<Questions> GetAllByLessonId(int Id)
        {
            return _context.Questions.Include(x => x.Lesson).Where(x => x.LessonId == Id).ToList();
        }
    }
}
