using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.BookAppoinment
{
    internal class BookAppointmentHandler : IRequestHandler<BookAppointmentRequest, bool>
    {
        private readonly IAdminRepository _adminRepository;

        public BookAppointmentHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<bool> Handle(BookAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await _adminRepository.BookAppointment(request._appoinment);
        }
    }
}
