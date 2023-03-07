using formProject.Models.ViewModel.CarDetailsView;

namespace formProject.Factory.CarDetailsFactory
{
    public interface ICarDetailsFactory
    {
        CarDetailsViewModel GetCarEngineTypeTyreBrand();
        Task SaveModelAsync(CarDetailsViewModel model);
    }
}
