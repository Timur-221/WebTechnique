using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class Specialty //специальность
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; } // Продолжительность обучения в годах

        public ICollection<Student> Students { get; set; }
    }
}
