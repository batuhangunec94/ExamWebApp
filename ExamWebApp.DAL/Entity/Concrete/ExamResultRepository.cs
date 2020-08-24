using ExamWebApp.DAL.Context;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.DAL.Entity.Concrete
{
    public class ExamResultRepository:BaseRepository<ExamResult>,IExamResultRepository
    {
        private ProjectContext _context;
        public ExamResultRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }
    }
}
