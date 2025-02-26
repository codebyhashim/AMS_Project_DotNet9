using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.RegisterPatient
{
    public class RegisterPatientHandler : IRequestHandler<RegisterPatientRequest, bool>
    {
        private readonly IPatientRepository _patientRepository;

        public RegisterPatientHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<bool> Handle(RegisterPatientRequest request, CancellationToken cancellationToken)
        {
            return await _patientRepository.RegisterPatient(request.patient);
        }
    }
}
