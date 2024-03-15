using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTechnique.DBase;
using WebTechnique.Models.DBModel;
using WebTechnique.Models.RegisterStudentModel;

namespace WebTechnique.Controllers
{
    public class RegisterStudentController : Controller
    {
        private readonly DataBase _dataBase;

        public RegisterStudentController(DataBase dataBase)
        {
            _dataBase = dataBase;
        }
        public IActionResult RegisterStudentPage()
        {
            ViewBag.Specialties = _dataBase.Specialties.ToList();
            ViewBag.Groups = _dataBase.Groups.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Surname = model.Surname,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    Age = model.Age,
                    DateOfBirth = model.DateOfBirth,
                    DatePost = model.DatePost,
                    Phone = model.Phone,
                    Specialty = _dataBase.Specialties.ToList().FirstOrDefault(x=>x.Name == model.Specialty),
                    Group = _dataBase.Groups.ToList().FirstOrDefault(x => x.Name == model.Group)
                };

                if (model.PDFDiplomaFile != null && model.PDFDiplomaFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.PDFDiplomaFile.CopyToAsync(memoryStream);
                        student.PDFDiplom = memoryStream.ToArray();
                    }
                }

                _dataBase.Students.Add(student);
                await _dataBase.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Перенаправляем пользователя на главную страницу после успешной регистрации
            }
            // Если модель не прошла валидацию, возвращаем пользователя на страницу регистрации с ошибками
            ViewBag.Specialties = _dataBase.Specialties.ToList();
            ViewBag.Groups = _dataBase.Groups.ToList();
            return View(model);
        }
    }
}
