using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.DAL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using ExamWebApp.UI.Models.DTO;
using ExamWebApp.UI.Models.IdentityModel;
using ExamWebApp.UI.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ILessonService _lessonService;
        private IQuestionsService _questionsService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;
        
        public AdminController(ILessonService lessonService,IQuestionsService questionsService, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager )
        {
            _roleManager = roleManager;
            _lessonService = lessonService;
            _questionsService = questionsService;
            _userManager = userManager;
            
        }
        // Home
        // Home
        // Home
        // Home
        // Home
        public IActionResult Index()
        {
            return View();
        }
        // Lesson
        // Lesson
        // Lesson
        // Lesson
        // Lesson
        [HttpGet]
        public IActionResult AddLesson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLesson(LessonDTO entity)
        {
            if (entity.StartingDate > DateTime.Now)
            {
                if (entity.EndDate > entity.StartingDate)
                {
                    if (ModelState.IsValid)
                    {
                        var entities = new Lesson()
                        {
                            LessonName = entity.LessonName,
                            StartingDate = entity.StartingDate,
                            EndDate = entity.EndDate,
                            Price = entity.Price,
                            TransactionTime = DateTime.Now


                        };
                        _lessonService.Add(entities);
                        return RedirectToAction("ListLesson");
                    }
                    return View(entity);
                }
                else
                {
                    TempData["message"] = "Başlangıç Tarihi Bitiş Tarihinden Sonra olamaz";
                    return new RedirectResult("/Admin/AddLesson");
                }
            }
            else
            {
                TempData["message"] = "Geçmiş Tarihten Başlayamaz";
                return new RedirectResult("/Admin/AddLesson");
            } 
        }
        public IActionResult ListLesson()
        {
            List<Lesson> model = _lessonService.GetAll();
            return View(model);
        }
        public IActionResult EditLesson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Lesson entity = _lessonService.GetById((int)id);
            var model = new LessonDTO()
            {
                Id = entity.Id,
                LessonName = entity.LessonName,
                StartingDate = entity.StartingDate,
                EndDate = entity.EndDate,
                Price = entity.Price
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditLesson(LessonDTO entity)
        {
            var model = _lessonService.GetById(entity.Id);

            model.LessonName = entity.LessonName;
            model.StartingDate = entity.StartingDate;
            model.EndDate = entity.EndDate;
            model.Price = entity.Price;

            _lessonService.Update(model);
            return RedirectToAction("ListLesson");
        }
        [HttpPost]
        public IActionResult DeleteLesson(int id)
        {
            
            Lesson model = _lessonService.GetById(id);
            List<Questions> modelQuestion = _questionsService.GetAll().Where(x => x.LessonId == model.Id).ToList();
            foreach (var item in modelQuestion)
            {
                _questionsService.Delete(item);
            };
            _lessonService.Delete(model);
            return RedirectToAction("ListLesson");
        }
        // Questions
        // Questions
        // Questions
        // Questions
        // Questions
        public IActionResult AddQuestion()
        {
            ViewBag.Lessons = _lessonService.GetAll();
            
            return View();
        }
        [HttpPost]
        public IActionResult AddQuestion(QuestionsVM entities, int lessonId)
        {
            
            if (ModelState.IsValid)
            {
                
                foreach (var item in entities.Questions)
                {
                    Questions model = new Questions();
                    model.Question = item.Question;
                    model.Option1 = item.Option1;
                    model.Option2 = item.Option2;
                    model.Option3 = item.Option3;
                    model.Option4 = item.Option4;
                    model.LessonId = lessonId;
                    _questionsService.Add(model);
                    
                }
                return Redirect("/Admin/AddQuestionReply/"+lessonId);
            }
            ViewBag.Lessons = _lessonService.GetAll();
            TempData["message"] = "Boş Alanları Doldurunuz";
            return View(entities);
            

            
        }
        public IActionResult AddQuestionReply(int Id)
        {
            
            List<Questions> model = _questionsService.GetAll().Where(x => x.LessonId == Id).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddQuestionReply(List<Questions> questions)
        {
            foreach (var item in questions)
            {
                Questions model = _questionsService.GetById(item.Id);
                model.Reply = item.Reply;
                _questionsService.Update(model);
            }
            return RedirectToAction("EditListQuestion");
        }
        public IActionResult EditListQuestion()
        {
            List<Lesson> model = _lessonService.GetAll();
            return View(model);
        }
        public IActionResult EditQuestion(int? Id)
        {
            

            var questionModel = _questionsService.GetById((int)Id);
            ViewBag.Lessons = _lessonService.GetAll();
            return View(new QuestionsDTO()
            {
                Id = questionModel.Id,
                Question = questionModel.Question,
                Option1 = questionModel.Option1,
                Option2 = questionModel.Option2,
                Option3 = questionModel.Option3,
                Option4 = questionModel.Option4,
                urlId = questionModel.LessonId

            });
        }
        [HttpPost]
        public IActionResult EditQuestion(Questions model, int urlId)
        {
            

            _questionsService.Update(model);
            return Redirect("/Admin/ListQuestion/"+ urlId);
        }
        public IActionResult ListQuestion(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            List<Questions> questionModel = _questionsService.GetAllByLessonId((int)Id);

            return View(questionModel);

        }
        [HttpPost]
        public IActionResult DeleteQuestion(int? Id, int? LessonId)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Questions model = _questionsService.GetById((int)Id);
            _questionsService.Delete(model);
            return Redirect("/Admin/ListQuestion/"+ LessonId);
        }
    }
}