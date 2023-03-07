using formProject.Models.ViewModel.JobApplicationView;
using formProject.Models.ViewModel.StudentView;

namespace formProject.Factory.JobApplicationFactory
{
    public interface IJobAplicationFactory
    {
        JobApplicationViewModel GetJobNameLocationInterestType();
        // StudentViewModel GetStudentInterest();
        Task SaveModelAsync(JobApplicationViewModel model);
        List<JobDetailsReportViewModel> GetJobDetailsReportViewModel();
    }
}
