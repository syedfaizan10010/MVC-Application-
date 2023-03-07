using Dapper;
using formProject.DbContext;
using formProject.Factory.BookingTicketFactory;
using formProject.Models.DomainObject.BookingTicketDomain;

namespace formProject.Models.Repository
{
    public class BookingTicketDataOperation : IBookingTicket
    {
        private DapperDbContext _DapperDbContext;
        public BookingTicketDataOperation(DapperDbContext DapperDbContext)
        {
            _DapperDbContext = DapperDbContext;
        }
        public async Task<int> AddNewBookingTicket(BookingTicket bookingTicket)
        {
            var query = "AddNewBookingTicket";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var param = new DynamicParameters();
                param.Add("@UserName", bookingTicket.UserName);
                param.Add("@UserMail", bookingTicket.UserMail);
                param.Add("@UserAge", bookingTicket.UserAge);
                param.Add("@BookingFrom", bookingTicket.BookingFrom);
                param.Add("@BookingTo", bookingTicket.BookingTo);
                var result = con.Query<BookingTicket>(query,param:param,commandType:System.Data.CommandType.StoredProcedure);

            }
            return 1;
        }

        

        public List<Locations> GetAllLocations()
        {
            var query = "GetLocations";
            using(var con = _DapperDbContext.GetConnection())
            {
                con.Open();
                var result = con.Query<Locations>(query);
                return result.ToList();
            }
        }
    }
}
