namespace formProject.Models.DomainObject
{
    public interface IEmployee
    {
        Task<int> AddNewEmployee(Employee employee);

        EmployeeReport GetIndividualEmplooyee(int id);

        List<EmpStatus> GetEmpStatus();
        List<EmployeeReport> GetAllEmployee();
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int id);
    }
}
