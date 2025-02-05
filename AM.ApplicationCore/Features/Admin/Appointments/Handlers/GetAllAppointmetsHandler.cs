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
    public class GetAllAppointmetsHandler : IRequestHandler<GetAllAppoinmentsRequest, List<AppoinmentModel>>
    {
        private readonly IAdminRepository _adminRepository;

        public GetAllAppointmetsHandler(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }

        public async Task<List<AppoinmentModel>> Handle(GetAllAppoinmentsRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.ViewAppointments();
        }
    }
}
