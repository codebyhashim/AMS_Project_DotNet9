using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.UpdateDoctor
{
    public class UpdateDoctorRequest : IRequest<bool>
    {
        public readonly DoctorModel _doctor;
        

        public UpdateDoctorRequest(DoctorModel doctor)
        {
            _doctor = doctor;
            
        }
    }
}
