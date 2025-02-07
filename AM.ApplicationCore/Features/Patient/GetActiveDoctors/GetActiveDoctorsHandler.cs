using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetActiveDoctors
{
    public class GetActiveDoctorsHandler : IRequestHandler<GetActiveDoctorsRequest, List<DoctorModel>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetActiveDoctorsHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<List<DoctorModel>> Handle(GetActiveDoctorsRequest request, CancellationToken cancellationToken)
        {
            return await _patientRepository.GetActiveDoctors();

        }


        //return await _patientRepository.GetActiveDoctors();

    }
}
