using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.BookAppoinment
{
    public class BookAppointmentRequest : IRequest<bool>
    {
        public readonly AppoinmentModel _appoinment;

        public BookAppointmentRequest(AppoinmentModel appoinment)
        {
            _appoinment = appoinment;
        }
    }
}
