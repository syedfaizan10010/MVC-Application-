using Dapper;
using formProject.DbContext;
using formProject.Models.DomainObject.CarDetailsDomain;

namespace formProject.Models.Repository
{
    public class CarDetailsDataOperation : ICarDetails
    {
        private DapperDbContext _DapperDbContext;
        public CarDetailsDataOperation(DapperDbContext DapperDbContext)
        {
            _DapperDbContext= DapperDbContext;
        }
        public async Task<int> AddNewCarDetails(CarDetails carDetails)
        {
            var query = "AddNewCarDetails";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@CarName", carDetails.CarName);
                param.Add("@CarMake", carDetails.CarMake);
                param.Add("@CarEnginetypeId", carDetails.CarEngineTypeId);
                param.Add("@CarTypeId", carDetails.CarEngineTypeId);
                param.Add("@CarTyreBrandId", carDetails.CarTyreBrandId);
                var result = con.Query<CarDetails>(query,param:param,commandType:System.Data.CommandType.StoredProcedure);
            }
            return 1;

        }

        public List<CarType> GetCarTypes()
        {
            var query = "GetCarType";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<CarType>(query);
                return result.ToList();
            }
        }

        public List<CarEngineType> GetEngineTypes()
        {
            var query = "GetCarEngineType";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<CarEngineType>(query);
                return result.ToList();
            }
        }

        public List<CarTyreBrand> GetTyreBrands()
        {
            var query = "GetCarTyreBrand";
            using(var con=_DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<CarTyreBrand>(query);
                return result.ToList();
            }
            throw new NotImplementedException();
        }
    }
}
