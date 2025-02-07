using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.BookAppoinment
{
    public class BookAppointmentRequest : IRequest<bool>
    {
        public readonly AppointmentModel _appoinment;

        public BookAppointmentRequest(AppointmentModel appoinment)
        {
            _appoinment = appoinment;
        }
    }
}
