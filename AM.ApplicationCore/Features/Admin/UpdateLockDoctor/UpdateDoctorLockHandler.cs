using AM.ApplicationCore.Interfaces;
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
