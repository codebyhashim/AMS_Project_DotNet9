using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetAllAppoinments
{
    public class GetAllAppoinmentsRequest : IRequest<List<AppointmentModel>>
    {
    }
}
