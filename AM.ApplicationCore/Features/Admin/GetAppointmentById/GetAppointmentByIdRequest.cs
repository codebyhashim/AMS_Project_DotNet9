using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetAppointmentById
{
    public class GetAppointmentByIdRequest : IRequest<AppointmentModel>
    {
        public int Id { get; set; }
    }
}
