using formProject.Models.DomainObject;
using formProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Factory
    //Aggregative Pattern
    //Custrel Server
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly IEmployee _IEmployee;
        public EmployeeFactory(IEmployee IEmployee)
        {
            _IEmployee = IEmployee;
        }

        public EmployeeReportViewModel ConvertIndividualEmployee(int id)
        {
            var employee = _IEmployee.GetIndividualEmplooyee(id);
            EmployeeReportViewModel viewModel = new EmployeeReportViewModel
            {
                EmpId = employee.EmpId,
                EmpName = employee.EmpName,
                EmpCity = employee.EmpCity,
                EmpStatus = employee.EmpStatus,
                StatusName=employee.StatusName
            };
            var empStatus = _IEmployee.GetEmpStatus();
            var empStatusOption = empStatus.Select(e => new SelectListItem
            {
                Value = e.StatusId.ToString(),
                Text = e.StatusName


            }).ToList();
            viewModel.SelectEmpStatus = empStatusOption;
            return viewModel;



        }

        public async Task<List<EmployeeReportViewModel>> ConvertToGetViewModel()
        {
            var employee =_IEmployee.GetAllEmployee();
            var viewModel = new List<EmployeeReportViewModel>();
            var employeeModel = employee.Select(e => new EmployeeReportViewModel
            {
                EmpId=e.EmpId,
                EmpName = e.EmpName,
                EmpCity= e.EmpCity,
                StatusName=e.StatusName,


    }).ToList();
            return await Task.FromResult(employeeModel);
        }

        public  EmployeeViewModel ConvertToViewModel()
        {
           var empStatus =_IEmployee.GetEmpStatus();
            var empStatusOption = empStatus.Select(e => new SelectListItem
           {
               Value = e.StatusId.ToString(),
               Text = e.StatusName


           }).ToList();
            var viewModel = new EmployeeViewModel();
            viewModel.EmpStatusOptions = empStatusOption;
            
            return  viewModel;
        }

        public void DeleteEmployeeAsync(int id)
        {
            _IEmployee.DeleteEmployee(id);
        }

        public async Task SaveModelAsync(EmployeeViewModel model)
        {
            //throw new NotImplementedException();

            var employee = new Employee
            {
                EmpId = model.EmpId,
                EmpName = model.EmpName,
                EmpCity = model.EmpCity,
                EmpStatus = model.EmpStatus,
            };
            await _IEmployee.AddNewEmployee(employee);
        }

        public async Task SaveUpdateemployeeAsync(EmployeeViewModel model)
        {
            var employee = new Employee
            {
                EmpId = model.EmpId,
                EmpName = model.EmpName,
                EmpCity = model.EmpCity,
                EmpStatus = model.EmpStatus,
            };
            await _IEmployee.UpdateEmployee(employee);
        }
    }
}
