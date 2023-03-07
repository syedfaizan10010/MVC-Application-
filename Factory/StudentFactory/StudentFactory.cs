using formProject.Models.DomainObject;
using formProject.Models.DomainObject.StudentDomain;
using formProject.Models.ViewModel;
using formProject.Models.ViewModel.StudentView;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Factory.StudentFactory
{
    public class StudentFactory : IStudentFactory
    {
        private readonly IStudent _IStudent;
        public StudentFactory(IStudent IStudent)
        {
            _IStudent = IStudent;

        }
        public StudentViewModel GetStudentChoiceInterest()
        {

            var studentChoice = _IStudent.GetStudentChoice();
            var studentChoiceOption = studentChoice.Select(s => new SelectListItem
            {
                Value = s.StudentChoiceId.ToString(),
                Text = s.StudentChoiceName
            }).ToList();

            var studentInterest =_IStudent.GetStudentInterest();
            var studentInterestOption = studentInterest.Select(s => new SelectListItem
            {
                Value =s.StudentInterestId.ToString(),
                Text=s.StudentInterestName
            }).ToList();

            
            var viewModel = new StudentViewModel();
            viewModel.SelectStudentChoice = studentChoiceOption;

            viewModel.SelectStudentInterest = studentInterestOption;
            return viewModel;


        }

        public  List<StudentReportViewModel> GetStudentViewReports()
        {
            var student = _IStudent.GetStudentReport();
            var viewModel = new List<StudentReportViewModel>();
            var studentReportViewModel = student.Select(s => new StudentReportViewModel
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName,
                StudentChoiceName = s.StudentChoiceName,
                StudentInterestName = s.StudentInterestName,
                StudentRollNo = s.StudentRollNo
            }).ToList();
            return  studentReportViewModel;
        }
       

        public async Task SaveModelAsync(StudentViewModel model)
        {
            var student = new Student
            {
                StudentId = model.StudentId,
                StudentName = model.StudentName,
                StudentRollNo = model.StudentRollNo,
                StudentInterest = model.StudentInterest,
                StudentChoice = model.StudentChoice
            };
            await _IStudent.AddStudentAsync(student);
          
        }
    }
}
