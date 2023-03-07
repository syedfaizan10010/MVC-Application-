namespace formProject.Models.DomainObject.JobApplicationDomain
{
    public interface IJobApplication
    {
        Task<int> AddJobApplication(JobApplication jobApplication); 
        List<JobNamee> GetJobNames();
        List<JobLocation> GetJobLocations();
        List<JobType> GetJobTypes();
        List<JobInterest> GetJobInterests();
        List<JobDetailsReport> GetJobDetailsReport();

    }
}
