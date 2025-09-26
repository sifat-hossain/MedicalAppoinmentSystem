using FluentValidation;

namespace Datavanced.Applications.Actions.Doctors.Push;

public class PushDoctorValidator : AbstractValidator<PushDoctorCommand>
{
    public PushDoctorValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.Address)
             .NotNull()
             .NotEmpty()
             .WithMessage("Specialization is required.");

        RuleFor(x => x.Phone)
             .NotNull()
             .NotEmpty()
             .WithMessage("Phone number is required.");
    }
}
