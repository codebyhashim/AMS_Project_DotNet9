using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetPateint
{
    public class GetPatientHandler : IRequestHandler<GetPatientRequest, PatientModel>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<PatientModel> Handle(GetPatientRequest request, CancellationToken cancellationToken)
        {
            return await _patientRepository.GetPatient(request.Id);
        }
    }
}
