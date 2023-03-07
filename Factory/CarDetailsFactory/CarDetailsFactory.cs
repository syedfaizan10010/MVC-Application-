using formProject.Models.DomainObject.CarDetailsDomain;
using formProject.Models.ViewModel.CarDetailsView;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Factory.CarDetailsFactory
{
    public class CarDetailsFactory : ICarDetailsFactory
    {
        private readonly ICarDetails _ICarDetails;
        public CarDetailsFactory(ICarDetails ICarDetails)
        {
            _ICarDetails= ICarDetails;
        }

        public CarDetailsViewModel GetCarEngineTypeTyreBrand()
        {
            var CarEngineType = _ICarDetails.GetEngineTypes();
            var CarEngineTypeOptions = CarEngineType.Select(c => new SelectListItem
            {
                Value = c.CarEngineTypeId.ToString(),
                Text = c.CarEngineTypeName
            }).ToList();

            var CarType = _ICarDetails.GetCarTypes();
            var CarTypeOptions = CarType.Select(c => new SelectListItem
            {
                Value = c.CarTypeId.ToString(),
                Text = c.CarTypeName
            }).ToList();

            var CarTyre = _ICarDetails.GetTyreBrands();
            var CarTyreOptions = CarTyre.Select(c => new SelectListItem
            {
                Value = c.CarTyreBrandId.ToString(),
                Text = c.CarTyreBrandName
            }).ToList();

           
            var viewModel = new CarDetailsViewModel();
            viewModel.SelectCarEngineType = CarEngineTypeOptions;
            viewModel.SelectCarType = CarTypeOptions;
            viewModel.SelectCarTyreBrand = CarTyreOptions;

            //viewModel.SelectCarEngineType = CarEngineTypeOptions;
            //viewModel.SelectCarTyreBrand=CarEngineTypeOptions;

            //viewModel.SelectCarType = CarTypeOptions;
            //viewModel.SelectCarTyreBrand = CarTyreOptions;
            // viewModel.SelectCarTyreBrand= CarTyreBrandOptions;
            return viewModel;
        }

        public async Task SaveModelAsync(CarDetailsViewModel model)
        {
            var carDetail = new CarDetails
            {
                CarName = model.CarName,
                CarMake = model.CarMake,
                CarEngineTypeId = model.CarEngineTypeId,
                CarTypeId = model.CarTypeId,
                CarTyreBrandId = model.CarTyreBrandId,

            };
            await _ICarDetails.AddNewCarDetails(carDetail);
        }
    }
}
