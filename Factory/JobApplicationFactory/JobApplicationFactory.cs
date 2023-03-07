using formProject.Models.DomainObject.JobApplicationDomain;
using formProject.Models.ViewModel.JobApplicationView;
using formProject.Models.ViewModel.StudentView;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Factory.JobApplicationFactory
{
    public class JobApplicationFactory : IJobAplicationFactory
    {
        private IJobApplication _IJobApplication;
        public JobApplicationFactory(IJobApplication IJobApplication)
        {
            _IJobApplication = IJobApplication;

        }

        public  List<JobDetailsReportViewModel> GetJobDetailsReportViewModel()
        {
            var JobDetails =  _IJobApplication.GetJobDetailsReport();
           // var viewModel = new List<JobDetailsReportViewModel>();
            var jobDetailReportViewModel = JobDetails.Select(j => new JobDetailsReportViewModel
            {
                UserName = j.UserName,
                UserMailId = j.UserMailId,
                UserPhoneNo=j.UserPhoneNo,
                UserInterestName=j.UserInterestName,
                UserHobbies=j.UserHobbies,
                UserProjectDescription=j.UserProjectDescription,
                UserGraduationYear=j.UserGraduationYear,
                UserInstitueName =j.UserInstitueName,
                JobName= j.JobName,
                JobTypeName= j.JobTypeName,
                JobLocationName= j.JobLocationName,
            }).ToList();
            return (jobDetailReportViewModel);
        }

        public JobApplicationViewModel GetJobNameLocationInterestType()
        {
            var jobNames = _IJobApplication.GetJobNames();
            var jobNameOption = jobNames.Select(j => new SelectListItem
            {
                Value = j.JobId.ToString(),
                Text = j.JobName
            }).ToList();

            var jobLocation = _IJobApplication.GetJobLocations();
            var jobApplicationOption = jobLocation.Select(j => new SelectListItem
            {
                Value = j.JobLocationId.ToString(),
                Text = j.JobLocationName
            }).ToList();
            var jobType = _IJobApplication.GetJobTypes();
            var jobTypesOption = jobType.Select(j => new SelectListItem
            {
                Value = j.JobTypeId.ToString(),
                Text = j.JobTypeName
            }).ToList();
            
            
            var jobUserInterest = _IJobApplication.GetJobInterests();
            var jobInterestOption = jobUserInterest.Select(j => new SelectListItem
            {
                Value = j.UserInterestId.ToString(),
                Text = j.UserInterestName
            }).ToList();
            //var jobUserInterest = _IJobApplication.GetJobInterests();
            //var jobInterestOption = jobUserInterest.Select(j => new SelectListItem
            //{
            //    Value = j.UserInterestId.ToString(),
            //    Text = j.UserInterestName
            //}).ToList();


            var viewModel = new JobApplicationViewModel();
            viewModel.SelectJobName = jobNameOption;
            viewModel.SelectJobLocation = jobApplicationOption;
            viewModel.SelectJobType = jobTypesOption;
            viewModel.SelectUserInterest = jobInterestOption;
            return viewModel;
        }

        public async Task SaveModelAsync(JobApplicationViewModel model)
        {
            var jobApplication = new JobApplication
            {
                UserName = model.UserName,
                UserId = model.UserId,
                UserMailId = model.UserMailId,
                UserPhoneNo=model.UserPhoneNo,
                UserInterestId = model.UserInterestId,
                UserHobbies =model.UserHobbies,
                UserProjectDescription = model.UserProjectDescription,
                UserGraduationYear=model.UserGraduationYear,
                UserInstitueName =model.UserInstitueName,
                JobId = model.JobId,
                JobLocationId = model.JobLocationId,
                JobTypeId = model.JobTypeId

            };
            await _IJobApplication.AddJobApplication(jobApplication);
        }
    }
}
