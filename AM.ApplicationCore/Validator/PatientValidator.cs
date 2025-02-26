using AM.Models;
using FluentValidation;

namespace AM.ApplicationCore.Validator
{
    public class PatientValidator : AbstractValidator<PatientModel>
    {
        public PatientValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(20).WithMessage("Name must not exceed 20 characters");


            RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth is required")
            .LessThanOrEqualTo(x => DateTime.Now).WithMessage("select valid date");



            RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required")
            .MaximumLength(20).WithMessage("City must not exceed 20 characters");

            RuleFor(x => x.Gender)
            .NotNull().WithMessage("please select one option")
                .NotEmpty().WithMessage("Gender field is required ")
            .IsInEnum();

        }

        //public string Name { get; set; } = string.Empty;

        //public string? City { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public Gender Gender { get; set; }
    }
}
