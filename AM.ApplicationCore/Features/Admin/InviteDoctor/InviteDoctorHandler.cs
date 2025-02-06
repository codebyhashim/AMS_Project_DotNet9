using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.InviteDoctor
{
    public class InviteDoctorHandler : IRequestHandler<InviteDoctorRequest, DoctorModel>
    {
        private readonly IAdminRepository _adminRepository;

        public InviteDoctorHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }



        async Task<DoctorModel> IRequestHandler<InviteDoctorRequest, DoctorModel>.Handle(InviteDoctorRequest request, CancellationToken cancellationToken)
        {
            var doctor = await _adminRepository.InviteDoctor(request._doctor);
            return doctor;
        }
    }
}
