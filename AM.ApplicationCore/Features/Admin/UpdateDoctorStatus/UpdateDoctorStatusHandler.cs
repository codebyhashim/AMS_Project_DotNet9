using AM.ApplicationCore.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.UpdateDoctorStatus
{
    public class UpdateDoctorStatusHandler : IRequestHandler<UpdateDoctorStatusRequest, bool>
    {
        private readonly IAdminRepository _adminRepository;

        public UpdateDoctorStatusHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> Handle(UpdateDoctorStatusRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.DoctorStatusUpdate(request._doctor);
        }
    }
}
