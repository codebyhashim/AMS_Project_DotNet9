using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.BookAppoinment
{
    internal class BookAppointmentHandler : IRequestHandler<BookAppointmentRequest, bool>
    {
        private readonly IDoctorRepository _doctorRepository;

        public BookAppointmentHandler(IDoctorRepository doctorRepository)
        {
            this._doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(BookAppointmentRequest request, CancellationToken cancellationToken)
        {
            return await _doctorRepository.BookAppointment(request._appoinment);
        }

        //public async Task<bool> Handle(BookAppointmentRequest request, CancellationToken cancellationToken)
        //{
        //    //return await _doctorRepository.BookAppointment();
        //}
    }
}
