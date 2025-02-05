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
    public class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdRequest, DoctorModel>
    {
        private readonly IAdminRepository _adminRepository;

        public GetDoctorByIdHandler(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }

        public async Task<DoctorModel> Handle(GetDoctorByIdRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetDoctorById(request.id);
        }
    }
}
