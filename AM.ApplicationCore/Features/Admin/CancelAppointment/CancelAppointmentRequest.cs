using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.CancelAppointment
{
    public class CancelAppointmentRequest : IRequest<bool>
    {
        public AppoinmentModel _appointment;

        public CancelAppointmentRequest(AppoinmentModel appointment)
        {
            _appointment = appointment;
        }
    }
}
