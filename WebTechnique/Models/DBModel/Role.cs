using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<PersonToRole> PersonToRoles { get; set; }
    }
}
