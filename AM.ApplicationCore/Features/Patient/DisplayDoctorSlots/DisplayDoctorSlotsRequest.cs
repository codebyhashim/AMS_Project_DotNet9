using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.ApplicationCore.Features.Patient.DisplayDoctorSlots
{
    public class DisplayDoctorSlotsRequest : IRequest<List<SelectListItem>>
    {
        public readonly int doctorId;
        public readonly string date;

        public DisplayDoctorSlotsRequest(int doctorId, string Date)
        {
            this.doctorId = doctorId;
            date = Date;
        }
    }
}
