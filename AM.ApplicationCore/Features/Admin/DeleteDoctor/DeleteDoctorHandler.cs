using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.DeleteDoctor
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorRequest, bool>
    {
        private readonly IAdminRepository _adminRepository;

        public DeleteDoctorHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> Handle(DeleteDoctorRequest request, CancellationToken cancellationToken)
        {
            var doctor = await _adminRepository.GetDoctorById(request.id);
            return await _adminRepository.DeleteDoctor(doctor);

        }
    }
}
