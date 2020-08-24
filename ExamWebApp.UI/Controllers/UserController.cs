using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamWebApp.BLL.Entity.Abstraction;
using ExamWebApp.Entities.Entity.Concrete;
using ExamWebApp.UI.Models.DTO;
using ExamWebApp.UI.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamWebApp.UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ILessonService _lessonService;
        private UserManager<AppUser> _userManager;
        private IStudentLessonService _studentLesson;
        private IQuestionsService _questionsSerice;
        private IExamService _examService;
        private IExamResultService _examResultService;
        public UserController(ILessonService lessonService, UserManager<AppUser> userManager, IStudentLessonService studentLesson,IQuestionsService questionsService, IExamService examService, IExamResultService examResultService)
        {
            _lessonService = lessonService;
            _userManager = userManager;
            _studentLesson = studentLesson;
            _questionsSerice = questionsService;
            _examService = examService;
            _examResultService = examResultService;
        }
        public async Task<IActionResult> AddExam(int lessonId, string userName)
        {
            AppUser student = await _userManager.FindByNameAsync(userName);
            Lesson lesson = _lessonService.GetById(lessonId);
            List<Questions> questions = _questionsSerice.GetAll().Where(x => x.LessonId == lessonId).ToList();
            if (questions.Count == 0)
            {
                return RedirectToAction("ErrorQuestion");
            }
            else
            {
                try
                {
                    StudentLesson entity = new StudentLesson()
                    {
                        AppUserId = student.Id,
                        AppUser = student,
                        LessonId = lessonId,
                        Lesson = lesson
                    };
                    _studentLesson.Add(entity);

                    var studentId = student.Id;
                    var totalCount = questions.Count();
                    var point = 100 / totalCount;
                    foreach (var item in questions)
                    {
                        Exam model = new Exam()
                        {
                            StudentId = studentId,
                            Question = item.Question,
                            Name = lesson.LessonName,
                            Option1 = item.Option1,
                            Option2 = item.Option2,
                            Option3 = item.Option3,
                            Option4 = item.Option4,
                            Option5 = "Empty",
                            Right = item.Reply,
                            Reply = null,
                            Time = totalCount,
                            Point = point,
                            LessonId = lessonId
                            
                        };
                        _examService.Add(model);

                    }
                    return Redirect("/Home/Details/" + lessonId);
                }
                catch (Exception)
                {

                    return NotFound();
                }
            }  
        }
        public IActionResult ErrorQuestion()
        {
            return View();
        }
        public async Task<IActionResult> ListExam()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Exam> exams = _examService.GetAll().Where(x => x.StudentId == user.Id).ToList();
            
                        return View(exams);


            
        }
        public async Task<IActionResult> StartExam(int Id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Exam> exams = _examService.GetAll().Where(x => x.StudentId == user.Id && x.Reply == null && x.LessonId == Id).ToList();
            if (exams.Count == 0)
            {
                return Redirect("/User/FinishExam/" + Id);
            }
            foreach (var item in exams)
            {
                      return View(item);
            }
            

            return View();
        }
        [HttpPost]
        public IActionResult StartExam(Exam exam)
        {
            if (exam != null)
            {
                var newExam = _examService.GetById(exam.Id);
                newExam.Reply = exam.Reply;
                _examService.Update(newExam);
                List<Exam> exams = _examService.GetAll().Where(x => x.Reply != null).ToList();
                if (exams.Count == 0)
                {
                    return Redirect("/User/FinishExam/" + exam.LessonId);
                }
                foreach (var item in exams)
                {
                    var model = _examService.GetById(item.Id);
                    model.Time = exam.Time;
                    _examService.Update(model);
                    return RedirectToAction("StartExam");
                }
            }
            return Redirect("/User/StartExam"+exam.LessonId);
        }
        public async Task<IActionResult> FinishExam(int Id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Exam> model = _examService.GetAll().Where(x => x.LessonId == Id && x.StudentId == user.Id && x.Reply ==  x.Right).ToList();
            
            double resultPoint = model.Select(x => x.Point).FirstOrDefault();
            double totalRight = resultPoint * model.Count;
            
            var resultModel = new ExamResult()
            {
                ExamName = model.Select(x => x.Name).FirstOrDefault(),
                StudentId = user.Id,
                TransactionTime = DateTime.Now,
                Result = totalRight,

            };
            _examResultService.Add(resultModel);
            return RedirectToAction("ListResult");
        }
        public async Task<IActionResult> ListResult()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<ExamResult> model = _examResultService.GetAll().Where(x => x.StudentId == user.Id).ToList();
            return View(model);
        }
    }
}