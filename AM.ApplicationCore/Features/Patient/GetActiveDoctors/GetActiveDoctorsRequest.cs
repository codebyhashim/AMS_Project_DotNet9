using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Features.Patient.GetActiveDoctors;
using AM.Models;
using FluentValidation;
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