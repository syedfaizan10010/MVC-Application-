using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Models.ViewModel.StudentView
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentRollNo { get; set; }
        public int StudentChoice { get; set; }
        public int StudentInterest { get; set; }
        public List<SelectListItem> SelectStudentChoice { get; set; }
        public List<SelectListItem> SelectStudentInterest { get; set; }


    }
}
