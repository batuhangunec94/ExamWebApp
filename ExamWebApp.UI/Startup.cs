using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.BLL.Entity.Concrete;
using ExamWebApp.DAL.Context;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.DAL.Entity.Concrete;
using ExamWebApp.Entities.Entity.Concrete;
using ExamWebApp.UI.IdentityEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExamWebApp.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.EnableEndpointRouting = false);
            // Services
            services.AddScoped<IExamResultService, ExamResultManager>();
            services.AddScoped<ILessonService, LessonManager>();
            services.AddScoped<IQuestionsService, QuestionsManager>();
            services.AddScoped<IExamService,ExamManager>();
            services.AddScoped<IStudentLessonService, StudentLessonManager>();

            // Repositories
            services.AddScoped<IStudentLessonRepository, StudentLessonRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamResultRepository, ExamResultRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();

            // Context
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //  Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ProjectContext>()
                .AddDefaultTokenProviders();

            //  Identity Options
            services.Configure<IdentityOptions>(x =>
            {

                x.Password.RequiredLength = 5;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;

                x.Lockout.MaxFailedAccessAttempts = 5;
                x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                x.Lockout.AllowedForNewUsers = true;

                x.User.RequireUniqueEmail = false;


                x.SignIn.RequireConfirmedEmail = false;

            });
            // Cookie
            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = "/account/login";
                x.LogoutPath = "/account/logout";
                x.AccessDeniedPath = "/account/accessdenied";
                x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                x.SlidingExpiration = true;
                x.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ExamWeApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });
            //
            services.AddMvc(x => x.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            SeedIdentity.Seed(userManager, roleManager, Configuration).Wait();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();
        }
    }
}
