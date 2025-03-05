using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Models;
using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetAllSlots
{
    public class GetAllSlotsHandler : IRequestHandler<GetAllSlotsRequest, List<TimeSlotsModel>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllSlotsHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public Task<List<TimeSlotsModel>> Handle(GetAllSlotsRequest request, CancellationToken cancellationToken)
        {
            return _patientRepository.GetAllSlots();
        }
    }
}
