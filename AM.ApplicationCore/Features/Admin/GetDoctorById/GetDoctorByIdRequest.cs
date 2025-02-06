using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.GetDoctorById
{
    public class GetDoctorByIdRequest : IRequest<DoctorModel>
    {
        public int id;


    }
}
