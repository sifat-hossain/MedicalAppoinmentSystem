using FluentValidation;

namespace Datavanced.Applications.Actions.Appointments.Push.CreateAppoinment;

public class PushAppointmentValidator : AbstractValidator<PushAppointmentCommand>
{
    public PushAppointmentValidator()
    {
        RuleFor(appointment => appointment.AppoitmentDate)
            .NotEmpty()
            .NotNull()
            .WithMessage("Appoitment Date can not be null or empty");

        RuleFor(appointment => appointment.PatientId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Patient information can not be null or empty");

        RuleFor(appointment => appointment.DoctorId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Doctor information can not be null or empty");

        RuleFor(appointment => appointment.Diagnosis)
            .NotEmpty()
            .NotNull()
            .WithMessage("Diagnosis can not be null or empty");
    }
}
