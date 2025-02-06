using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetAllAppoinments
{
    public class GetAllAppointmetsHandler : IRequestHandler<GetAllAppoinmentsRequest, List<AppoinmentModel>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAllAppointmetsHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<List<AppoinmentModel>> Handle(GetAllAppoinmentsRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.ViewAppointments();
        }
    }
}
