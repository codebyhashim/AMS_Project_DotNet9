using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.ViewAppoinments
{
    public class ViewAppointmentsHandler : IRequestHandler<ViewAppointmentsRequest, List<AppointmentModel>>
    {
        private readonly IPatientRepository _patientRepository;

        public ViewAppointmentsHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        //public Task<List<AppoinmentModel>> Handle(ViewAppointmentsRequest request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<AppointmentModel>> Handle(ViewAppointmentsRequest request, CancellationToken cancellationToken)
        {
            return await _patientRepository.ViewAppoinments(request.patient);

        }
    }
}
