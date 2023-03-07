using formProject.Models.DomainObject.BookingTicketDomain;
using formProject.Models.ViewModel;
using formProject.Models.ViewModel.BookingTicketView;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Factory.BookingTicketFactory
{
    public class BookingTicketFactory : IBookingTicketFactory
    {
        private readonly IBookingTicket _IBookingTicket;
        public BookingTicketFactory(IBookingTicket IBookingTicket)
        {
            _IBookingTicket = IBookingTicket;
        }

        public BookingTicketViewModel GetAllLocations()
        {
            var Locations = _IBookingTicket.GetAllLocations();
            var LocationOptions = Locations.Select(l => new SelectListItem
            {
                Value = l.LocationId.ToString(),
                Text = l.LocationPlaces
            }).ToList();

            var viewModel = new BookingTicketViewModel();
            viewModel.SelectLocations = LocationOptions;
            return viewModel;
            //var empStatus = _IEmployee.GetEmpStatus();
            //var empStatusOption = empStatus.Select(e => new SelectListItem
            //{
            //    Value = e.StatusId.ToString(),
            //    Text = e.StatusName


            //}).ToList();
            //var viewModel = new EmployeeViewModel();
            //viewModel.EmpStatusOptions = empStatusOption;

            //return viewModel;
        }

        public async Task SaveModelAsync(BookingTicketViewModel model)
        {
            var BookingTicket = new BookingTicket
            {
                UserName = model.UserName,
                UserMail = model.UserMail,
                UserAge = model.UserAge,
                BookingFrom = model.BookingFrom,
                BookingTo = model.BookingTo
            };
            await _IBookingTicket.AddNewBookingTicket(BookingTicket);
        }
    }
}
