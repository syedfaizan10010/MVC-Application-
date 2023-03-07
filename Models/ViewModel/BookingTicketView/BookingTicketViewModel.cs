using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace formProject.Models.ViewModel.BookingTicketView
{
    public class BookingTicketViewModel
    {
        public int BookkingId { get; set; }
        [Required(ErrorMessage = "User Name is Required")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "Email field is required")]
        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0-9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<> 
        ()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$", ErrorMessage = "Please enter a Valid Mail")]
        public string UserMail { get; set; }

        [Required(ErrorMessage ="Age is required")]
        [Range (1,60, ErrorMessage ="Age Must be between 1- 60 years")]
        public int UserAge { get; set; }
        public int BookingFrom { get; set; }
        public int BookingTo { get; set; }
        public List<SelectListItem> SelectLocations { get; set; }
    }
}
