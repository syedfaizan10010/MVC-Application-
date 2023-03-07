namespace formProject.Models.DomainObject.BookingTicketDomain
{
    public class BookingTicket
    {
        public int BookkingId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public int UserAge { get; set; }
        public int BookingFrom { get; set; }
        public int BookingTo { get; set; }
    }
}
