using FluentValidation;

namespace Datavanced.Applications.Actions.Patients.Push;

public class PushPatientValidator : AbstractValidator<PushPatientCommand>
{
    public PushPatientValidator()
    {
        RuleFor(patient => patient.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name can not be null or empty");

        RuleFor(patient => patient.Phone)
            .NotEmpty()
            .NotNull()
            .WithMessage("Phone can not be null or empty");

        RuleFor(patient => patient.Gender)
            .NotEmpty()
            .NotNull()
            .WithMessage("Gender can not be null or empty");

        RuleFor(patient => patient.Age)
            .NotEmpty()
            .NotNull()
            .WithMessage("Age can not be null or empty");

        RuleFor(patient => patient.AgeType)
           .NotEmpty()
           .NotNull()
           .WithMessage("AgeType can not be null or empty");
    }
}