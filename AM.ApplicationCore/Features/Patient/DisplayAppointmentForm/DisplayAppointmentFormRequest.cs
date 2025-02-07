using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.DisplayAppointmentForm
{
    public class DisplayAppointmentFormRequest: IRequest<AppointmentModel>
    {
        public required PatientModel Patients { get; set; }
    }
}
