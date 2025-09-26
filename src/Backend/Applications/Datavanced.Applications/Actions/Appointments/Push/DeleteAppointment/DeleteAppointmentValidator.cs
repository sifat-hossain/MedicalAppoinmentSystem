using FluentValidation;

namespace Datavanced.Applications.Actions.Appointments.Push.DeleteAppointment;

public class DeleteAppointmentValidator : AbstractValidator<DeleteAppointmentCommand>
{
    public DeleteAppointmentValidator()
    {
        RuleFor(appointment => appointment.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id can not be null or empty");
    }
}
