using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetDoctorAppointments
{
    public class GetDoctorAllAppoinmentsRequest : IRequest<List<AppointmentModel>>
    {
        public int Id { get; set; }
    }
}
