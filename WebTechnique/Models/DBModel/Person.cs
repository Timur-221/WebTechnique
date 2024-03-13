using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebTechnique.Models.DBModel
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Surname { get; set; } //Фамилия
        public string Name { get; set; }//Имя
        public string Patronymic { get; set; }//Отчесвто
        public int Age { get; set; }//Возраст
        public DateTime DateOfBirth { get; set; } //Дата рождения

        public List<PersonToRole> PersonToRoles { get; set; }
    }
}
