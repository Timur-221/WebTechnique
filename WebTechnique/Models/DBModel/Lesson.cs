using System.ComponentModel.DataAnnotations;

namespace WebTechnique.Models.DBModel
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } // Навигационное свойство к преподавателю урока

        public int GroupId { get; set; }
        public Group Group { get; set; } // Навигационное свойство к группе урока

        public int SubjectId { get; set; }
        public Subject Subject { get; set; } 
    }
}
