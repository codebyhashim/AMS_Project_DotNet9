using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.BookAppoinment
{
    public class BookAppointmentRequest : IRequest<bool>
    {
        public readonly AppointmentModel _appoinment;

        public BookAppointmentRequest(AppointmentModel appoinment)
        {
            this._appoinment = appoinment;
        }
    }
}
