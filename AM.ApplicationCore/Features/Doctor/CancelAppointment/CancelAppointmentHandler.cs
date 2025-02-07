using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.CancelAppointment
{
    public class CancelAppointmentHandler : IRequestHandler<CancelAppointmentRequest, bool>
    {
        private readonly IDoctorRepository _doctorRepository;

        public CancelAppointmentHandler(IDoctorRepository doctorRepository)
        {
            this._doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(CancelAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await _doctorRepository.CanceleAppointment(request._appointment);
        }
    }
}
