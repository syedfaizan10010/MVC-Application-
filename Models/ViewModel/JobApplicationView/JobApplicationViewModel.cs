using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace formProject.Models.ViewModel.JobApplicationView
{
    public class JobApplicationViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="User Name is Required")]
        [MaxLength(5)]
        //[Range(1,5, ErrorMessage = "User Name must be less than 5 Characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Email field is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0-9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<> 
        ()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$", ErrorMessage = "Please enter a Valid Mail")]

        public string UserMailId { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string UserPhoneNo { get; set; }
        public int UserInterestId { get; set; }
        public string UserHobbies { get; set; }
        public string UserProjectDescription { get; set; }
        public int UserGraduationYear { get; set; }
        public string UserInstitueName { get; set; }
        public int JobId { get; set; }
        public int JobLocationId { get; set; }
        public int JobTypeId { get; set; }
        public List<SelectListItem> SelectJobName { get; set; }
        public List<SelectListItem> SelectJobLocation { get; set; }
        public List<SelectListItem> SelectJobType { get; set; }
        public List<SelectListItem> SelectUserInterest { get; set; }

    }
}
