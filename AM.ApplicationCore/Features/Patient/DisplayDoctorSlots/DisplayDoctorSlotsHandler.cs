using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.ApplicationCore.Features.Patient.DisplayDoctorSlots
{
    public class DisplayDoctorSlotsHandler : IRequestHandler<DisplayDoctorSlotsRequest, List<SelectListItem>>
    {
        private readonly IPatientRepository _patientRepository;

        public DisplayDoctorSlotsHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public Task<List<SelectListItem>> Handle(DisplayDoctorSlotsRequest request, CancellationToken cancellationToken)
        {
            return _patientRepository.DisplaySlots(request.doctorId,request.date);
        }
    }
}
