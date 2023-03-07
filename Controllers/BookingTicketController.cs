using formProject.Factory.BookingTicketFactory;
using formProject.Models.ViewModel.BookingTicketView;
using Microsoft.AspNetCore.Mvc;

namespace formProject.Controllers
{
    public class BookingTicketController : Controller
    {
        private readonly IBookingTicketFactory _IBookingTicketFactory;
        public BookingTicketController(IBookingTicketFactory IBookingTicketFactory)
        {
            _IBookingTicketFactory= IBookingTicketFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewTicket()
        {
            var locations = _IBookingTicketFactory.GetAllLocations();
            return View(locations);
        }
        public async Task<IActionResult> AddNewTicketPost(BookingTicketViewModel model) 
        {
            await _IBookingTicketFactory.SaveModelAsync(model);
            return RedirectToAction("AddNewTicket");
        }
    }
}
