using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.BookAppoinments
{
    public class BookAppointmentsRequest : IRequest<bool>
    {
        public readonly AppointmentModel appointment;

        public BookAppointmentsRequest(AppointmentModel appointment)
        {
            this.appointment = appointment;
        }
    }
}
