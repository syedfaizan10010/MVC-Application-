using Dapper;
using formProject.DbContext;
using formProject.Models.DomainObject.JobApplicationDomain;

namespace formProject.Models.Repository
{
    public class JobApplicationDataOperation : IJobApplication
    {
        private DapperDbContext _DapperDbContext;
        public JobApplicationDataOperation(DapperDbContext DapperdbContext)
        {
            _DapperDbContext = DapperdbContext;
        }
        public async Task<int> AddJobApplication(JobApplication jobApplication)
        {
            var query = "AddNewJobApplication";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@UserName", jobApplication.UserName);
                param.Add("@UserMailId", jobApplication.UserMailId);
                param.Add("@UserPhoneNo", jobApplication.UserPhoneNo);
                param.Add("@UserInterestId", jobApplication.UserInterestId);
                param.Add("@UserHobbies", jobApplication.UserHobbies);
                param.Add("@UserProjectDescription", jobApplication.UserProjectDescription);
                param.Add("@UserGraduationYear", jobApplication.UserGraduationYear);
                param.Add("@UserInstituteName", jobApplication.UserInstitueName);
                param.Add("@JobId", jobApplication.JobId);
                param.Add("@JobLocationId", jobApplication.JobLocationId);
                param.Add("@JobTypeId", jobApplication.JobTypeId);
                var result = con.Query<JobApplication>(query,param:param,commandType:System.Data.CommandType.StoredProcedure);
            }
            return 1;
        }

        public  List<JobDetailsReport> GetJobDetailsReport()
        {
            var query = "JobDetails";
            using( var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<JobDetailsReport>(query);
                return result.ToList();
            }
        }

        public List<JobInterest> GetJobInterests()
        {
            var query = "GetJobInterest";
            using (var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<JobInterest>(query);
                return result.ToList();
            }
        }

        public List<JobLocation> GetJobLocations()
        {
            var query = "GetJobLocation";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<JobLocation>(query);
                return result.ToList();
            }
        }

        public List<JobNamee> GetJobNames()
        {
            var query = "GetJobName";
            using (var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<JobNamee>(query);
                return result.ToList();
            }
        }

        public List<JobType> GetJobTypes()
        {
            var query = "GetJobType";
            using (var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<JobType>(query);
                return result.ToList();
            }
        }
    }
}
