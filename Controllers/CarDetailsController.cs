using formProject.Factory.CarDetailsFactory;
using formProject.Models.ViewModel.CarDetailsView;
using Microsoft.AspNetCore.Mvc;

namespace formProject.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly ICarDetailsFactory _CarDetailsFactory;
        public CarDetailsController(ICarDetailsFactory CarDetailsFactory)
        {
            _CarDetailsFactory= CarDetailsFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewCar()
        {
            var cars = _CarDetailsFactory.GetCarEngineTypeTyreBrand();
            return View(cars);
        }
        public async Task<IActionResult> AddNewCarPost(CarDetailsViewModel model)
        {
            await _CarDetailsFactory.SaveModelAsync(model);
            return RedirectToAction("AddNewCar");
        }
    }
}
