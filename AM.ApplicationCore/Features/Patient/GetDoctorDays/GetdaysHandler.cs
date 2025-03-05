using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetDoctorDays
{
    public class GetdaysHandler : IRequestHandler<GetDaysRequest, List<string>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetdaysHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public Task<List<string>> Handle(GetDaysRequest request, CancellationToken cancellationToken)
        {
            return _patientRepository.GetDays(request.doctorId);   
        }
    }
}
