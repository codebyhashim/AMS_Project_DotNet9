using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.DisplayAppointmentForm
{
    public class DisplayAppointmentFormRequest : IRequest<AppointmentModel>
    {
        public required PatientModel Patients { get; set; }
    }
}
