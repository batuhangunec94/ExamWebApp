using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.Entities.Entity.Concrete
{
    public class Lesson:Base
    {
        public string LessonName { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Price { get; set; }
        public int TeacherId { get; set; }
        public virtual AppUser Teacher { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }

    }
}
