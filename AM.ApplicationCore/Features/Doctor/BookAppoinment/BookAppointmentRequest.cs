using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.BookAppoinment
{
    public class BookAppointmentRequest : IRequest<bool>
    {
        private readonly AppoinmentModel _appoinment;

        public BookAppointmentRequest(AppoinmentModel appoinment)
        {
            this._appoinment = appoinment;
        }
    }
}
