using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.DashboardCounts
{
    public class DashboardCountsHandler : IRequestHandler<DashboardCountsRequest, DashboardCountsModel>
    {
        private readonly IAdminRepository _adminRepository;

        public DashboardCountsHandler(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }

        public async Task<DashboardCountsModel> Handle(DashboardCountsRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.Counts();
        }
    }
}
