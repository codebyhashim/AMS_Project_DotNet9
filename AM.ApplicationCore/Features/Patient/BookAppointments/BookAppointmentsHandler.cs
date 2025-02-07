using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Interfaces;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.BookAppoinments
{
    public class BookAppointmentsHandler : IRequestHandler<BookAppointmentsRequest, bool>
    {
        private readonly IPatientRepository _patientRepository;

        public BookAppointmentsHandler(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<bool> Handle(BookAppointmentsRequest request, CancellationToken cancellationToken)
        {
            return await _patientRepository.GetAppointments(request.appointment);
        }
    }
}
