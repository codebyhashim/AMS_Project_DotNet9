using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.CancelAppointment
{
    public class CancelAppointmentRequest : IRequest<bool>
    {
        public AppointmentModel _appointment;

        public CancelAppointmentRequest(AppointmentModel appointment)
        {
            _appointment = appointment;
        }
    }
}
