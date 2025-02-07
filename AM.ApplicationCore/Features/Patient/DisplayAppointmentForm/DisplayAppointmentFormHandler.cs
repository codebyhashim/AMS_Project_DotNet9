using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.DisplayAppointmentForm
{
    public class DisplayAppointmentFormHandler : IRequestHandler<DisplayAppointmentFormRequest, AppointmentModel>
    {
        private readonly IPatientRepository _patientRepository;

        public DisplayAppointmentFormHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public   async Task<AppointmentModel> Handle(DisplayAppointmentFormRequest request, CancellationToken cancellationToken)
        {
            return await _patientRepository.ShowAppointmetForm(request.Patients);
        }
    }
}
