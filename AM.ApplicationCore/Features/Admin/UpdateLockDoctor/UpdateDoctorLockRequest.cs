using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.UpdateLockDoctor
{
    public class UpdateDoctorLockRequest : IRequest<bool>
    {
        public readonly DoctorModel _doctor;
        public readonly List<string> availabilityDays;
        public readonly List<string> availabilityTimeSlot;

        public UpdateDoctorLockRequest(DoctorModel doctor, List<string> AvailabilityDays, List<string> AvailabilityTimeSlot)
        {
            this._doctor = doctor;
            availabilityDays = AvailabilityDays;
            availabilityTimeSlot = AvailabilityTimeSlot;
        }
    }
}
