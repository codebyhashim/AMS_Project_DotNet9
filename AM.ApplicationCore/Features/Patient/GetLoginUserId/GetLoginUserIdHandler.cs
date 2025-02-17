using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetLoginUserId
{
    public class GetLoginUserIdHandler : IRequestHandler<GetLoginUserIdRequest, string>
    {
        private readonly IPatientRepository _patientRepository;

        public GetLoginUserIdHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public Task<string> Handle(GetLoginUserIdRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_patientRepository.GetLoginPatient());
        }
    }
}
