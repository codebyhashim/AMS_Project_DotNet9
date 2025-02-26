using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.RegisterPatient
{
    public class RegisterPatientRequest : IRequest<bool>
    {
        public readonly PatientModel patient;

        public RegisterPatientRequest(PatientModel patient)
        {
            this.patient = patient;
        }
    }
}
