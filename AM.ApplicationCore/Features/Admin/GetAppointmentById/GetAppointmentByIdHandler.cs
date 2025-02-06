using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetAppointmentById
{
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdRequest, AppoinmentModel>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAppointmentByIdHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<AppoinmentModel> Handle(GetAppointmentByIdRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetAppointmentById(request.id);
        }
    }
}
