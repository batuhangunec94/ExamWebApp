using ExamWebApp.Entities.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWebApp.UI.Models.IdentityModel
{
    public class EditRoleModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Admins { get; set; }
        public IEnumerable<AppUser> Users { get; set; }


    }
}
