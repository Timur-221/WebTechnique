using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebTechnique.DBase;
using WebTechnique.Models.LessonModel;
using WebTechnique.MyClass;

namespace WebTechnique.Controllers
{
    public class LessonController : Controller
    {
        private readonly DataBase _dataBase;

        public LessonController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public IActionResult LessonPage()
        {
            var lessons = GetLessonsFromDatabase(); 
            return View(lessons);
        }

        private List<LessonViewModel> GetLessonsFromDatabase()
        {
            var userClaimValue = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Authentication)?.Value;
            var ListLisionData = _dataBase.Lessons
                .Include(lesson => lesson.Teacher)
                .Include(lesson => lesson.Group)
                .Include(lesson => lesson.Subject)
                .Where(x=>x.Teacher.PersonId == Convert.ToInt32(userClaimValue))
                .ToList();

            var ListLision = new List<LessonViewModel>();

           foreach (var lesson in ListLisionData)
           {
                var tempLesson = new LessonViewModel();
                tempLesson.DayOfWeek = lesson.DayOfWeek;
                tempLesson.Room = lesson.Room;
                tempLesson.SubjectName = lesson.Subject.Name;
                tempLesson.StartTime = lesson.StartTime;
                tempLesson.EndTime = lesson.EndTime;
                tempLesson.GroupName = lesson.Group.Name;
                ListLision.Add(tempLesson);
  
           }

           return ListLision;
        }
    }
}
