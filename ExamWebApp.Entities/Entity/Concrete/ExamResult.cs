using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamWebApp.Entities.Entity.Concrete
{
    public class ExamResult:Base
    {
        public string ExamName { get; set; }
        public double Result { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual AppUser Student { get; set; }
    }
}
