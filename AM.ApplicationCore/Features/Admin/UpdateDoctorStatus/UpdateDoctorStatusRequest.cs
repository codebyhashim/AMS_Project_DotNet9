using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.UpdateDoctorStatus
{
    public class UpdateDoctorStatusRequest : IRequest<bool>
    {
        public readonly DoctorModel _doctor;

        public UpdateDoctorStatusRequest(DoctorModel doctor)
        {
            _doctor = doctor;
        }
    }
}
