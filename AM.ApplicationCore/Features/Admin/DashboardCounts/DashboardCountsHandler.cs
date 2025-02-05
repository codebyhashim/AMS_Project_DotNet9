using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.DashboardCounts
{
    public class DashboardCountsHandler : IRequestHandler<DashboardCountsQuery, DashboardCountsModel>
    {
        private readonly IAdminRepository _adminRepository;

        public DashboardCountsHandler(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }

        public async Task<DashboardCountsModel> Handle(DashboardCountsQuery request, CancellationToken cancellationToken)
        {
            return await _adminRepository.Counts();
        }
    }
}
