using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class PersonToRole
    {
        [Key]
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
