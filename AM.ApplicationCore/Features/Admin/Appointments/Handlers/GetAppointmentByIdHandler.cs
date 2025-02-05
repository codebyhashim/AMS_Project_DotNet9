using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Features.Admin.Appointments.Queries;
using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.Appointments.Handlers
{
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdRequest, AppoinmentModel>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAppointmentByIdHandler(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }

        public async Task<AppoinmentModel> Handle(GetAppointmentByIdRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetAppointmentById(request.id);
        }
    }
}
