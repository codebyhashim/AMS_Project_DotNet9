using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.InviteDoctor
{
    public class InviteDoctorRequest : IRequest<DoctorModel>
    {
        public readonly DoctorModel _doctor;

        public InviteDoctorRequest(DoctorModel doctor)
        {
            _doctor = doctor;
        }
    }
}
