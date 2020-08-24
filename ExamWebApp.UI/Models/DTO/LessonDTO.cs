using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWebApp.UI.Models.DTO
{
    public class LessonDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="İsim alanı zorunlu")]
        public string LessonName { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage ="Fiyat Giriniz")]
        [Range(0, 10000 ,ErrorMessage ="En Yüksek 10bin TL Girilebilir ")]
        public int? Price { get; set; }
        public DateTime TransactionTime { get; set; }
        public int TeacherId { get; set; }
    }
}
