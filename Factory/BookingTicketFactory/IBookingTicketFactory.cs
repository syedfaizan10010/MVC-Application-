using formProject.Models.ViewModel.BookingTicketView;

namespace formProject.Factory.BookingTicketFactory
{
    public interface IBookingTicketFactory
    {
         BookingTicketViewModel GetAllLocations();
        Task SaveModelAsync(BookingTicketViewModel model);
    }
}
