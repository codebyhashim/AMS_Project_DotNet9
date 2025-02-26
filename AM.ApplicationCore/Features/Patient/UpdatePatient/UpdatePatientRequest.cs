using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.UpdatePatient
{
    public class UpdatePatientRequest : IRequest<bool>
    {
        public readonly PatientModel patient;

        public UpdatePatientRequest(PatientModel patient)
        {
            this.patient = patient;
        }
    }
}
