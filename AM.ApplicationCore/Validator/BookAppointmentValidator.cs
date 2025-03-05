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
            RuleFor(x => x.BookedSlots)
            .NotEmpty().WithMessage("Please Select a Time  slot");
            RuleFor(x => x.AppointmentDate)
            .NotEmpty()
            .WithMessage("Appointment Date is required.");

            // Optionally, you can add more validation logic like checking if the date is in the future, etc.
            RuleFor(x => x.AppointmentDate).NotEmpty().WithMessage("Please select a valid appointment date.");
                //.GreaterThan(DateTime.Now.dat)
                //.WithMessage("Appointment Date must be in the future.");


            RuleFor(x => x.DoctorId)
            .GreaterThan(0).WithMessage("Please select a Doctor.");
        }

    }
}
