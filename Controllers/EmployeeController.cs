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
            var emp =  _IEmployeeFactory.ConvertToViewModel();

            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewEmployeePost(EmployeeViewModel empModel)
        {
            
                await _IEmployeeFactory.SaveModelAsync(empModel);
                return  RedirectToAction("GetEmployee");
        }

        public async Task<IActionResult> GetEmployee()
        {       
            var employee =await  _IEmployeeFactory.ConvertToGetViewModel();
            return View(employee);
        }

        public async Task<IActionResult> UpdateEmployee(int id)
        {

            var employee =  _IEmployeeFactory.ConvertIndividualEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult>UpdateEmployeePost(EmployeeViewModel empModel)
        {
            await _IEmployeeFactory.SaveUpdateemployeeAsync(empModel);
            return RedirectToAction("GetEmployee");
        }
        public IActionResult DeleteEmployee(int id)
        {
            _IEmployeeFactory.DeleteEmployeeAsync(id);
            return RedirectToAction("GetEmployee");
        }


    }
}
