using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; } // Дата рождения
        public DateTime? DatePost { get; set; } // Дата поступления
        public byte[]? PDFDiplom { get; set; }//Диплом об окончании школы
        public string? Phone {  get; set; }//Телефон

        public int SpecialtyId { get; set; } // Внешний ключ для связи со специальностью
        public Specialty Specialty { get; set; } // Навигационное свойство к специальности

        public int GroupId { get; set; } 
        public Group Group { get; set; } 

    }
}
