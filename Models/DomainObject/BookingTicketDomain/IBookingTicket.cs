namespace formProject.Models.DomainObject.BookingTicketDomain
{
    public interface IBookingTicket
    {
        Task<int> AddNewBookingTicket(BookingTicket bookingTicket);

        List<Locations> GetAllLocations();
    }
}
