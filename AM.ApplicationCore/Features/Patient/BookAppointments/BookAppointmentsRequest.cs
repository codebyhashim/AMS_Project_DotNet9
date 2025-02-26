using AM.ApplicationCore.Features.Patient.BookAppoinments;
using AM.Models;
using FluentValidation;
using MediatR;

namespace AM.ApplicationCore.Features.Patient.BookAppoinments
{
    public class BookAppointmentsRequest : IRequest<bool>
    {
        public readonly AppointmentModel appointment;

        public BookAppointmentsRequest(AppointmentModel appointment)
        {
            this.appointment = appointment;
        }
    }
}

public class BookAppointmentsRequestValidator : AbstractValidator<BookAppointmentsRequest>
{
    public BookAppointmentsRequestValidator()
    {
        RuleFor(x => x.appointment.AppointmentDate)
            .NotEmpty().
            WithMessage("name is required").
            GreaterThan(DateTime.Now).WithMessage("Appointment date must in future")
            .LessThan(DateTime.Now.AddYears(1)).
            WithMessage("Appointment date must be with in the next year");



    }
}