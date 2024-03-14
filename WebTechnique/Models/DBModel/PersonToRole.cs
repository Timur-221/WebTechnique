using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class PersonToRole
    {
        [Key]
        public int Id { get; set; }

        // Внешний ключи для связи с таблицами Person и Role
        public int? PersonId { get; set; } // Разрешаем null для PersonId
        public Person Person { get; set; }

        public int? RoleId { get; set; } // Разрешаем null для RoleId
        public Role Role { get; set; }

    }
}
