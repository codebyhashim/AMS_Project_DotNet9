using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AM.ApplicationCore.Features.Admin.CreateDoctor;
using AM.Models;
using FluentValidation;

namespace AM.ApplicationCore.Validator
{
    public class DoctorValidator : AbstractValidator<DoctorModel>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email  is required")
            .EmailAddress().WithMessage("Please provide a valid email address");

            RuleFor(x => x.WaitTime)
            .NotEmpty().WithMessage("WaitTime  is required");
            RuleFor(x => x.Speciality).NotEmpty().WithMessage("Speciality  is required")
             .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.");

            RuleFor(x => x.AvailabilityDays)
            .NotEmpty().WithMessage("AvailabilityDays  is required");

            RuleFor(x => x.AvailabilityHours)
            .NotEmpty().WithMessage("AvailabilityHours  is required");

            RuleFor(x => x.City)
            .NotEmpty().WithMessage("City  is required")
            .MaximumLength(100).WithMessage("City can't be longer than 100 characters.");

            

            RuleFor(x => x.Degree)
            .NotEmpty().WithMessage("Degree is required")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.");
            
            RuleFor(x => x.Experience)
           .NotEmpty().WithMessage("Experience is required");

            RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Experience is required")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .Matches(@"^03[0-9]{9}$").WithMessage("Please enter a valid Pakistan mobile number starting with 03 followed by 9 digits.");

            RuleFor(x => x.Description)
           .NotEmpty().WithMessage("Description is required")
           .MaximumLength(300).WithMessage("Description can't be longer than 300 characters.");
        }
    }
}
