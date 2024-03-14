using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebTechnique.Models.DBModel
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<PersonToRole> PersonToRoles { get; set; }
    }
}
