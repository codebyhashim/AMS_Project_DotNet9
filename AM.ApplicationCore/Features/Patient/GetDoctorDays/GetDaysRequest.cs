using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetDoctorDays
{
    public class GetDaysRequest:IRequest<List<string>>
    {
        public readonly int doctorId;

        public GetDaysRequest(int doctorId)
        {
            this.doctorId = doctorId;
        }
    }
}
