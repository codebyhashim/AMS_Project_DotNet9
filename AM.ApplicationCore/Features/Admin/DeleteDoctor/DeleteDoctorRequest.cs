using MediatR;

namespace AM.ApplicationCore.Features.Admin.DeleteDoctor
{
    public class DeleteDoctorRequest : IRequest<bool>
    {
        public int id { get; set; }
        //public readonly DoctorModel _doctor;

        //public DeleteDoctorCommand(DoctorModel doctor)
        //{
        //    this._doctor = doctor;
        //}
    }
}
