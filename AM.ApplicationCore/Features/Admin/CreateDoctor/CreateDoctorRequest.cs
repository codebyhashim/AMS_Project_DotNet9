using AM.ApplicationCore.Features.Admin.CreateDoctor;
using AM.Models;
using FluentValidation;
using MediatR;
using Microsoft.Identity.Client;

namespace AM.ApplicationCore.Features.Admin.CreateDoctor
{
    public class CreateDoctorRequest : IRequest<bool>
    {
        public readonly DoctorModel _doctor;
       
        public CreateDoctorRequest(DoctorModel doctor)
        {
            _doctor = doctor;

        }
    }
}
//public class createDoctorRequestValidator : AbstractValidator<CreateDoctorRequest>
//{
//    public createDoctorRequestValidator()
//    {
//        RuleFor(x => x._doctor.Name)
//            .NotEmpty()
//            .WithMessage("name is required");
//    }
//}
