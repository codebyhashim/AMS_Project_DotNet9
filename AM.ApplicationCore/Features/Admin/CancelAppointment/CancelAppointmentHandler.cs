using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.CancelAppointment
{
    public class CancelAppointmentHandler : IRequestHandler<CancelAppointmentRequest, bool>
    {
        private readonly IAdminRepository _adminRepository;

        public CancelAppointmentHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> Handle(CancelAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.CancelAppointment(request._appointment);
        }
    }
}
