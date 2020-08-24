using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWebApp.UI.Models.DTO
{
    public class QuestionsDTO
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Option1 { get; set; }
        [Required]
        public string Option2 { get; set; }
        [Required]
        public string Option3 { get; set; }
        [Required]
        public string Option4 { get; set; }
        public string Reply { get; set; }
        [Required]
        public int LessonId { get; set; }
        public int? urlId { get; set; }
    }
}
