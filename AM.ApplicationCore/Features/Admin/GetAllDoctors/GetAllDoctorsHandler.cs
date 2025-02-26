using AM.ApplicationCore.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetAllDoctors
{
    public class GetAllDoctorsHandler : IRequestHandler<GetAllDoctorsRequest, List<DoctorModel>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAllDoctorsHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<List<DoctorModel>> Handle(GetAllDoctorsRequest request, CancellationToken cancellationToken)
        {

            return await _adminRepository.ViewDoctors();
        }
    }
}
