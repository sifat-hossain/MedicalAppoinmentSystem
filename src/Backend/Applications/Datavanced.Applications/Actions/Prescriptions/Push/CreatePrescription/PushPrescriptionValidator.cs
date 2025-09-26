using FluentValidation;

namespace Datavanced.Applications.Actions.Prescriptions.Push.CreatePrescription;

public class PushPrescriptionValidator : AbstractValidator<PushPrescriptionCommand>
{
    public PushPrescriptionValidator()
    {
        RuleFor(x => x.Dosage)
            .NotNull()
            .NotEmpty()
            .WithMessage("Dosage is required.");

        RuleFor(x => x.StartDate)
             .NotNull()
             .NotEmpty()
             .WithMessage("StartDate is required.");

        RuleFor(x => x.EndDate)
             .NotNull()
             .NotEmpty()
             .WithMessage("EndDate is required.");

        RuleFor(x => x.MedicineId)
             .NotNull()
             .NotEmpty()
             .WithMessage("MedicineId is required.");

        RuleFor(x => x.AppoitmentId)
             .NotNull()
             .NotEmpty()
             .WithMessage("AppoitmentId is required.");
    }
}
