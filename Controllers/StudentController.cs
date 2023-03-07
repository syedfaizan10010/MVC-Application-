using formProject.Factory.StudentFactory;
using formProject.Models.ViewModel.StudentView;
using Microsoft.AspNetCore.Mvc;

namespace formProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentFactory _IStudentFactory;
        public StudentController(IStudentFactory IStudentFactory)
        {
            _IStudentFactory = IStudentFactory;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewStudent()
        {
            var studentChoiceInterest = _IStudentFactory.GetStudentChoiceInterest();
            return View(studentChoiceInterest);
        }
        public async Task<IActionResult> AddNewStudentPost(StudentViewModel model)
        {
            await _IStudentFactory.SaveModelAsync(model);
            return RedirectToAction("AddNewStudent");
        }
        public async Task<IActionResult> GetStudentReport()
        {
            var student = _IStudentFactory.GetStudentViewReports();
            return View(student);   
        }

    }
}
