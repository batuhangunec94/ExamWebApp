using ExamWebApp.Entities.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamWebApp.DAL.Context
{
    public class ProjectContext:IdentityDbContext<AppUser>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {

        }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Questions> Questions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentLesson>().HasKey(x => new { x.AppUserId, x.LessonId });
            builder.Entity<StudentLesson>().Ignore(x => x.AppUser);
            base.OnModelCreating(builder);
        }
    }
    

}
