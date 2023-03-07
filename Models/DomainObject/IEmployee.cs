namespace formProject.Models.DomainObject
{
    public interface IEmployee
    {
        Task<int> AddNewEmployee(Employee employee);
        List<EmpStatus> GetEmpStatus();
        List<EmployeeReport> GetAllEmployee();
    }
}
