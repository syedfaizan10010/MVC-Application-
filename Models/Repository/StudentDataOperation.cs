using Dapper;
using formProject.DbContext;
using formProject.Models.DomainObject.StudentDomain;

namespace formProject.Models.Repository
{
    public class StudentDataOperation : IStudent
    {
        private DapperDbContext _DapperDbContext;
        public StudentDataOperation(DapperDbContext DapperdbContext)
        {
            _DapperDbContext = DapperdbContext;
        }
        public async Task<int> AddStudentAsync(Student student)
        {
            var query = "AddNewStudentDetail";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@StudentName", student.StudentName);
                param.Add("@StudentRollNo", student.StudentRollNo);
                param.Add("@StudentChoice", student.StudentChoice);
                param.Add("@StudentInterest", student.StudentInterest);
                var result = con.Query<Student>(query,param:param,commandType:System.Data.CommandType.StoredProcedure);
            }
            return 1;


        }

        public List<StudentChoice> GetStudentChoice()
        {
            var query = "GetStudentChoiceDetail";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<StudentChoice>(query);
                return result.ToList();
            }
        }

        public List<StudentInterest> GetStudentInterest()
        {
            var query = "GetStudentInterestDetail";
            using (var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<StudentInterest>(query);
                return result.ToList();
            }
        }

        public List<StudentReport> GetStudentReport()
        {
            var query = "StudentDetails";
            using(var con =_DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<StudentReport>(query);
                return result.ToList();
            }
        }
    }
}
