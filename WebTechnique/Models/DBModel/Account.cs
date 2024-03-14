using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public int? PersonToRoleId { get; set; }
        public virtual PersonToRole PersonToRole { get; set; }
    }
}
