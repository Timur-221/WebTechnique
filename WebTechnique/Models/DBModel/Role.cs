using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } //название роли
        public string Description { get; set; } // описание роли
        public List<string> Permissions { get; set; } // права доступа
        public DateTime CreatedAt { get; set; } // дата назначения роли
        public bool IsActive { get; set; } // Флаг, указывающий, активна ли данная роль в системе. Это может быть полезно, если вы хотите временно отключить определенные роли без удаления их из базы данных.
        public List<PersonToRole> PersonToRoles { get; set; }
    }
}
