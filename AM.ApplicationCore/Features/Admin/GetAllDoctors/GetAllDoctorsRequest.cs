using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetAllDoctors
{
    public class GetAllDoctorsRequest : IRequest<List<DoctorModel>>
    {

    }
}
