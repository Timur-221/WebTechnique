using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
