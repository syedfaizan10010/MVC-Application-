namespace formProject.Models.DomainObject.StudentDomain
{
    public interface IStudent
    {
        Task<int> AddStudentAsync(Student student);
        List<StudentChoice> GetStudentChoice();
        List<StudentInterest> GetStudentInterest();
        List<StudentReport> GetStudentReport();
    }
}
