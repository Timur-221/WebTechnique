using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
