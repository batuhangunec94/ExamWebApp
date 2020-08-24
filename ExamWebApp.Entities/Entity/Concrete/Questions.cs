using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.Entities.Entity.Concrete
{
    
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Reply { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
