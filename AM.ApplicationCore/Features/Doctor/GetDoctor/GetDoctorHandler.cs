using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetDoctor
{
    public class GetDoctorHandler : IRequestHandler<GetDoctorRequest, DoctorModel>
    {
        
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorHandler(IDoctorRepository doctorRepository)
        {
            this._doctorRepository = doctorRepository;
        }

        public async Task<DoctorModel> Handle(GetDoctorRequest request, CancellationToken cancellationToken)
        {
            return await _doctorRepository.GetDoctor(request.Id);  
        }
    }
}
