using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetAppoinmentById
{
    public class GetAppointmemtByIdRequest : IRequest<AppointmentModel>
    {
        public int Id { get; set; }
    }
}
