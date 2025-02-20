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
        public readonly List<string> availabilityDays;

        public CreateDoctorRequest(DoctorModel doctor, List<string> AvailabilityDays)
        {
            _doctor = doctor;
            availabilityDays = AvailabilityDays;
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
