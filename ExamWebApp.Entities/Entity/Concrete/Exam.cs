using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamWebApp.Entities.Entity.Concrete
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }
        public string Reply { get; set; }
        public string Right { get; set; }
        public int Time { get; set; }
        public double Point { get; set; }
        public DateTime EntryTime { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual AppUser Student { get; set; }
    }
}
