using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetAppoinmentById
{
    public class GetAppointmemtByIdHandler : IRequestHandler<GetAppointmemtByIdRequest, AppointmentModel>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetAppointmemtByIdHandler(IDoctorRepository doctorRepository)
        {
            this._doctorRepository = doctorRepository;
        }

        public async Task<AppointmentModel> Handle(GetAppointmemtByIdRequest request, CancellationToken cancellationToken)
        {
            return await _doctorRepository.GetAppointment(request.Id);
        }
    }
}
