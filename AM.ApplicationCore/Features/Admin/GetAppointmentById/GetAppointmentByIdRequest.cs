using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetAppointmentById
{
    public class GetAppointmentByIdRequest : IRequest<AppoinmentModel>
    {
        public int id { get; set; }
    }
}
