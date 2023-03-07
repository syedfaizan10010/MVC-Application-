using formProject.Factory.JobApplicationFactory;
using formProject.Models.ViewModel.JobApplicationView;
using Microsoft.AspNetCore.Mvc;

namespace formProject.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly IJobAplicationFactory _IJobAplicationFactory;
        public JobApplicationController(IJobAplicationFactory IJobAplicationFactory)
        {
            _IJobAplicationFactory=IJobAplicationFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult AddNewJob()
        {
            var jobApplication = _IJobAplicationFactory.GetJobNameLocationInterestType();
            return View(jobApplication);
        }

        public async Task<IActionResult>AddNewJobPost(JobApplicationViewModel model)
        {
            await _IJobAplicationFactory.SaveModelAsync(model);
            return RedirectToAction("AddNewJob");
        }

        public async Task<IActionResult>GetJobDetailsReport()
        {
            var jobDetails = _IJobAplicationFactory.GetJobDetailsReportViewModel();
            return View(jobDetails);
        }
    }
}
