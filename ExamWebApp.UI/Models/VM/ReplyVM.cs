using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWebApp.UI.Models.VM
{
    public class ReplyVM
    {
        public int Id { get; set; }
        public string Reply { get; set; }
        public List<Questions> questions { get; set; }
    }
}
