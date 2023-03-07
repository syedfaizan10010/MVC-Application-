using formProject.Factory;
using formProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace formProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeFactory _IEmployeeFactory;
        public EmployeeController(IEmployeeFactory IEmployeeFactory)
        {
            _IEmployeeFactory= IEmployeeFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public   IActionResult AddNewemployee()
        {
            var emp = _IEmployeeFactory.ConvertToViewModel();
            return View(emp);
        }
        public async Task<IActionResult> AddNewEmployeePost(EmployeeViewModel empModel)
        {
            
                await _IEmployeeFactory.SaveModelAsync(empModel);

            
           return  RedirectToAction("AddNewEmployee");
        }

        public async Task<IActionResult> GetEmployee()
        {       
            var employee =await  _IEmployeeFactory.ConvertToGetViewModel();
            return View(employee);
        }
    }
}
