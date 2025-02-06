using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetDoctorById
{
    public class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdRequest, DoctorModel>
    {
        private readonly IAdminRepository _adminRepository;

        public GetDoctorByIdHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<DoctorModel> Handle(GetDoctorByIdRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetDoctorById(request.id);
        }
    }
}
