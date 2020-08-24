using ExamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWebApp.UI.Models.VM
{
    public class ListExamVM
    {
        public List<Lesson> lessons { get; set; }
        public AppUser User { get; set; }
    }
}
