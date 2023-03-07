using formProject.Models.ViewModel;
using formProject.Models.ViewModel.StudentView;

namespace formProject.Factory.StudentFactory
{
    public interface IStudentFactory
    {
        StudentViewModel GetStudentChoiceInterest();
        // StudentViewModel GetStudentInterest();
        List<StudentReportViewModel> GetStudentViewReports();       
        Task SaveModelAsync(StudentViewModel model);
    }
}
