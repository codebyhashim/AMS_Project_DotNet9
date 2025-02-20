using AM.ApplicationCore.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetAppointmentById
{
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdRequest, AppointmentModel>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAppointmentByIdHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<AppointmentModel> Handle(GetAppointmentByIdRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetAppointmentById(request.Id);
        }
    }
}
