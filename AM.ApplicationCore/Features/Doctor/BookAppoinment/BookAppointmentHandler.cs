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

        public Task<bool> Handle(BookAppointmentRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> Handle(BookAppointmentRequest request, CancellationToken cancellationToken)
        //{
        //    //return await _doctorRepository.BookAppointment();
        //}
    }
}
