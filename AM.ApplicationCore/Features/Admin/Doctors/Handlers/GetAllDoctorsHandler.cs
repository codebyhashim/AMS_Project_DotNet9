using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Features.Admin.Doctors.Queries;
using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.Doctors.Handlers
{
    public class GetAllDoctorsHandler : IRequestHandler<GetAllDoctorsRequest, List<DoctorModel>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAllDoctorsHandler(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }

        public async Task<List<DoctorModel>> Handle(GetAllDoctorsRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.ViewDoctors();
        }
    }
}
