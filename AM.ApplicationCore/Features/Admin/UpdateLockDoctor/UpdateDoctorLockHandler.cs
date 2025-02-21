using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.UpdateLockDoctor
{
    public class UpdateDoctorLockHandler : IRequestHandler<UpdateDoctorLockRequest, bool>
    {
        private readonly IAdminRepository _adminRepository;

       
        public UpdateDoctorLockHandler(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }

        public async Task<bool> Handle(UpdateDoctorLockRequest request, CancellationToken cancellationToken)
        {
            
            return await _adminRepository.UpdateLockDoctor(request._doctor, request.availabilityDays, request.availabilityTimeSlot);
        }
    }
}
