using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.UpdatePatient
{
    public class UpdatePatientRequest : IRequest<bool>
    {
        public readonly PatientModel patient;

        public UpdatePatientRequest(PatientModel patient)
        {
            this.patient = patient;
        }
    }
}
