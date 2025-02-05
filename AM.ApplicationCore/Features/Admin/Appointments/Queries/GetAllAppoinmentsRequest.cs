using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.Appointments.Queries
{
    public class GetAllAppoinmentsRequest : IRequest<List<AppoinmentModel>>
    {
    }
}
