
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace formProject.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmpId { get; set; }
        [Required (ErrorMessage ="EmployeeName is Required***")]
        public string EmpName { get; set; }
        [Required (ErrorMessage =("Employee City is required"))]
        public string EmpCity { get; set; }
        public int EmpStatus { get; set; }
        public List<string> EmployeeDetails { get; set; }


        public List<SelectListItem> EmpStatusOptions { get; set; }
    }
   
}
