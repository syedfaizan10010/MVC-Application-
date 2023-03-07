using formProject.Models.DomainObject;
using formProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly IEmployee _IEmployee;
        public EmployeeFactory(IEmployee IEmployee)
        {
            _IEmployee = IEmployee;
        }

        public async Task<List<EmployeeReportViewModel>> ConvertToGetViewModel()
        {
            var employee =_IEmployee.GetAllEmployee();
            var viewModel = new List<EmployeeReportViewModel>();
            var employeeModel = employee.Select(e => new EmployeeReportViewModel
            {
                EmpName = e.EmpName,
                EmpCity= e.EmpCity,
                StatusName=e.StatusName,


    }).ToList();
            return await Task.FromResult(employeeModel);


            //public async Task<List<PlayerViewModel>> ConvertToViewModel()
            //{
            //    // var players =_IPlayer.GetAllPlayerDetails();
            //    var players = _IPlayer.GetAllPlayerDetails();
            //    var viewModel = new List<PlayerViewModel>();
            //    var playerModels = players.Select(p => new PlayerViewModel
            //    {
            //        PlayerId = p.PlayerId,
            //        PlayerName = p.PlayerName,
            //        PlayerRank = p.PlayerRank,
            //        JerseyNumber = p.JerseyNumber
            //    }).ToList();
            //    return await Task.FromResult(playerModels);
            //}
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
    }
}
