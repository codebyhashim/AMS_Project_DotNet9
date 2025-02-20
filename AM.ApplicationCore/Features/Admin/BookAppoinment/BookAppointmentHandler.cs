using AM.ApplicationCore.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.BookAppoinment
{
    internal class BookAppointmentHandler(IAdminRepository adminRepository) : IRequestHandler<BookAppointmentRequest, bool>
    {
        public async Task<bool> Handle(BookAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await adminRepository.BookAppointment(request._appoinment);
        }
    }
}
