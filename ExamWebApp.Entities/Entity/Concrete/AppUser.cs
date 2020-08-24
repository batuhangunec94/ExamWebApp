using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.Entities.Entity.Concrete
{
    public class AppUser:IdentityUser
    {
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
