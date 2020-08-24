using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamWebApp.Entities.Entity.Concrete
{
    public class StudentLesson
    {
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        
    }
}
