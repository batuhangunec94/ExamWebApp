using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using ExamWebApp.UI.Models.DTO;
using ExamWebApp.UI.Models.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private ILessonService _lessonService;
        private UserManager<AppUser> _userManager;
        public HomeController(ILessonService lessonService,UserManager<AppUser> userManager)
        {
            _lessonService = lessonService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            return View(new LessonVM()
            {
                Lessons = _lessonService.GetAll().Where(x => x.StartingDate < DateTime.Now && x.EndDate > DateTime.Now).ToList()
            });;
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {


                Lesson lesson = _lessonService.GetById((int)Id);
                Lesson lessonStudent = _lessonService.GetDetailByUser((int)Id);

                if (lesson == null)
                {
                    return NotFound();
                }

                if (User.Identity.IsAuthenticated)
                {
                    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    foreach (var item in lessonStudent.StudentLessons)
                    {
                        if (user.Id == item.AppUserId)
                        {
                            LessonDetailDTO model = new LessonDetailDTO()
                            {
                                Lesson = lesson,
                                StudentLessons = lessonStudent.StudentLessons.Where(x => x.LessonId == Id).ToList(),
                                StudentId = user.Id
                            };
                            return View(model);
                        }
                    }
                    LessonDetailDTO modelNull = new LessonDetailDTO()
                    {
                        Lesson = lesson,
                        StudentLessons = lessonStudent.StudentLessons.Where(x => x.LessonId == Id).ToList(),
                        StudentId = null
                    };
                    return View(modelNull);

                }
                else
                {
                    return View(new LessonDetailDTO()
                    {
                        Lesson = lesson,
                    });
                }
            }
        }
    }
}