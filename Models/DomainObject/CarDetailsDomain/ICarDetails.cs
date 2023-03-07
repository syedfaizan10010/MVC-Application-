namespace formProject.Models.DomainObject.CarDetailsDomain
{
    public interface ICarDetails
    {
        Task<int> AddNewCarDetails(CarDetails carDetails);
        List<CarEngineType> GetEngineTypes();
        List<CarType> GetCarTypes();
        List<CarTyreBrand> GetTyreBrands();
    }
}
