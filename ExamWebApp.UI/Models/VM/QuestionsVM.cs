using ExamWebApp.Entities.Entity.Concrete;
using ExamWebApp.UI.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWebApp.UI.Models.VM
{
    public class QuestionsVM
    {
        [Required]
        public int LessonId { get; set; }
        [Required]
        public List<QuestionsDTO> Questions { get; set; }
    }
}
