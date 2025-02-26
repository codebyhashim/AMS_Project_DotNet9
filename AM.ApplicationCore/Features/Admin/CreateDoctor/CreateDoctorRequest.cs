using AM.Models;
using MediatR;

namespace AM.ApplicationCore.Features.Admin.CreateDoctor
{
    public class CreateDoctorRequest : IRequest<bool>
    {
        public readonly DoctorModel _doctor;
        public readonly List<string> availabilityDays;
        public readonly List<string> availabilityTimeSlot;

        public CreateDoctorRequest(DoctorModel doctor, List<string> AvailabilityDays, List<string> AvailabilityTimeSlot)
        {
            _doctor = doctor;
            availabilityDays = AvailabilityDays;
            availabilityTimeSlot = AvailabilityTimeSlot;
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
