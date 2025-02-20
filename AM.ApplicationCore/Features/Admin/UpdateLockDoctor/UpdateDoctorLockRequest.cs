using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.UpdateLockDoctor
{
    public class UpdateDoctorLockRequest : IRequest<bool>
    {
        public readonly DoctorModel _doctor;
        public readonly List<string> availabilityDays;

        public UpdateDoctorLockRequest(DoctorModel doctor,  List<string> AvailabilityDays)
        {
            this._doctor = doctor;
            availabilityDays = AvailabilityDays;
        }
    }
}
