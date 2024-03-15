namespace WebTechnique.Models.RegisterStudentModel
{
    public class RegisterStudentViewModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DatePost { get; set; }
        public IFormFile PDFDiplomaFile { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public string Group { get; set; }
    }
}
