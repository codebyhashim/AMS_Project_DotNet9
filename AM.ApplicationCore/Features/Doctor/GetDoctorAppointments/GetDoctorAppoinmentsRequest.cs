using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetDoctorAppointments
{
    public class GetDoctorAppoinmentsRequest : IRequest<List<AppoinmentModel>>
    {
        public int Id { get; set; }
    }
}
