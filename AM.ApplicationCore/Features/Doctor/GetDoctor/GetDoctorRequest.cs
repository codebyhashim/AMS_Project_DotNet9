using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Doctor.GetDoctor
{
    public class GetDoctorRequest : IRequest<DoctorModel>
    {
        public string Id { get; set; }
    }
}
