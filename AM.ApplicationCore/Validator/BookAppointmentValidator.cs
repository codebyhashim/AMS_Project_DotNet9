using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Models;
using FluentValidation;

namespace AM.ApplicationCore.Validator
{
    public class BookAppointmentValidator : AbstractValidator<AppointmentModel>
    {
        public BookAppointmentValidator()
        {
            RuleFor(x => x.DoctorId)
                .NotEqual(0).WithMessage("not equl to zero")
                .NotNull().WithMessage("not null")
                .NotEmpty().WithMessage("must be select doctor");
        }
    }

    public class AbstractValidator
    {
    }
}
