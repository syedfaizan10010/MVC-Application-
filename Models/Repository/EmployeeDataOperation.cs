using Dapper;
using formProject.DbContext;
using formProject.Models.DomainObject;

namespace formProject.Models.Repository
{
    public class EmployeeDataOperation : IEmployee
    {
        private DapperDbContext _DapperDbContext;
        public EmployeeDataOperation(DapperDbContext DapperdbContext)
        {
            _DapperDbContext = DapperdbContext;
        }
        public async Task<int> AddNewEmployee(Employee employee)
        {
            var query = "AddNewEmployeeDetails";
            using( var con =_DapperDbContext.GetConnection() )
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@EmpName", employee.EmpName);
                param.Add("@EmpCity", employee.EmpCity);
                param.Add("@EmpStatus", employee.EmpStatus);
                param.Add("@IsDeleted", employee.IsDeleted);
                var result =  con.Query(query, param: param, commandType: System.Data.CommandType.StoredProcedure);


            }
            return  1 ;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var query = "DeleteEmployee";
            using(var con =_DapperDbContext.GetConnection())
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@EmpId", id);
                var result = con.Query(query, param: param, commandType: System.Data.CommandType.StoredProcedure);

            }
            return 1;
        }

        public List<EmployeeReport> GetAllEmployee()
        {
            var query = "GetEmployeeDetails";
            using(var con = _DapperDbContext.GetConnection() )
            {
                con.Open();
                var employee = con.Query<EmployeeReport>(query);
                 return employee.ToList();
            }

        }

        public List<EmpStatus> GetEmpStatus()
        {

            var query = "GetStatusDetail";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var employee = con.Query<EmpStatus>(query);
                return employee.ToList();
            }
        }

        public EmployeeReport GetIndividualEmplooyee(int id)
        {
            var query = "GetIndividualEmployee";
            using(var con = _DapperDbContext.GetConnection())
            {
                //con.Open();
                var param = new DynamicParameters();
                param.Add("@EmpId", id);

                var employee = con.Query<EmployeeReport>(query, param: param, commandType: System.Data.CommandType.StoredProcedure).First();
                return employee;
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            var query = "UpdateEmpoyee";
            using (var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@EmpId", employee.EmpId);
                param.Add("@EmpName", employee.EmpName);
                param.Add("@EmpCity", employee.EmpCity);
                param.Add("@EmpStatus", employee.EmpStatus);
                var result = con.Query(query, param: param, commandType: System.Data.CommandType.StoredProcedure);


            }
            return 1;
        }
    }
}
