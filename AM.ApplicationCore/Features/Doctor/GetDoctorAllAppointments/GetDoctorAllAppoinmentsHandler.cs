using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetDoctorAppointments
{
    public class GetDoctorAllAppoinmentsHandler : IRequestHandler<GetDoctorAllAppoinmentsRequest, List<AppointmentModel>>
    {
        public readonly IDoctorRepository _doctorRepository;

        public GetDoctorAllAppoinmentsHandler(IDoctorRepository doctorRepository)
        {
            this._doctorRepository = doctorRepository;
        }

        //public async Task<AppoinmentModel> Handle(GetDoctorAppoinmentsRequest request, CancellationToken cancellationToken)
        //{
        //    return await _doctorRepository.GetAppointment(request.Id);
        //}

        async Task<List<AppointmentModel>> IRequestHandler<GetDoctorAllAppoinmentsRequest, List<AppointmentModel>>.Handle(GetDoctorAllAppoinmentsRequest request, CancellationToken cancellationToken)
        {
            var appointment = await _doctorRepository.GetDoctorAppoinments(request.Id);
            return appointment;
        }
    }
}
