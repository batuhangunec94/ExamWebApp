using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWebApp.UI.Models.DTO
{
    public class LessonDetailDTO
    {
        public Lesson Lesson { get; set; }
        public string StudentId { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }
    }
}
