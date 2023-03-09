using formProject.Models.ViewModel;

namespace formProject.Factory
{
    public interface IEmployeeFactory
    {
        EmployeeViewModel ConvertToViewModel();
        Task SaveModelAsync(EmployeeViewModel model);



        Task<List<EmployeeReportViewModel>> ConvertToGetViewModel();

        EmployeeReportViewModel ConvertIndividualEmployee(int id);

        Task SaveUpdateemployeeAsync(EmployeeViewModel model);

        void DeleteEmployeeAsync(int id);
    }
}
