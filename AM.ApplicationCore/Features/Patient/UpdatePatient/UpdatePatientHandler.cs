using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.UpdatePatient
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientRequest, bool>
    {
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<bool> Handle(UpdatePatientRequest request, CancellationToken cancellationToken)
        {
            return await _patientRepository.UpdatePatient(request.patient);
        }
    }
}
