using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.ViewAppoinments
{
    public class ViewAppointmentsRequest : IRequest<List<AppointmentModel>>
    {
        public readonly PatientModel patient;

        public ViewAppointmentsRequest(PatientModel patient)
        {
            this.patient = patient;
        }
    }
}
