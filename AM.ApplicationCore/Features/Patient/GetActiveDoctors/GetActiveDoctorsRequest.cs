using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.GetActiveDoctors
{
    public class GetActiveDoctorsRequest : IRequest<List<DoctorModel>>
    {
    }

}
//public class DoctorListValidators : AbstractValidator<GetActiveDoctorsRequest>
//{
//    public DoctorListValidators()
//    {

//    }
//}