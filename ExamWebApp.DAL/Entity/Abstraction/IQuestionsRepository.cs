using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.DAL.Entity.Abstraction
{
    public interface IQuestionsRepository:IRepository<Questions>
    {
        List<Questions> GetAllByLessonId(int Id);
    }
}
