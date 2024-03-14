namespace WebTechnique.Models.LessonModel
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }
        public string TeacherName { get; set; }
        public string GroupName { get; set; }
        public string SubjectName { get; set; }
    }
}
