using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Models.ViewModel
{
    public class EmployeeReportViewModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpStatus { get; set; }
        public string EmployeeDetails { get; set; }
        public string StatusName { get; set; }
        public List<SelectListItem> SelectEmpStatus { get; set; }
    }
}
