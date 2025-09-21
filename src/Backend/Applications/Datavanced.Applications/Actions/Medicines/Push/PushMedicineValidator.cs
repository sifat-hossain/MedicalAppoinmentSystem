
using FluentValidation;

namespace Datavanced.Applications.Actions.Medicines.Push;

public class PushMedicineValidator : AbstractValidator<PushMedicineCommand>
{
    public PushMedicineValidator()
    {
        RuleFor(customer => customer.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name can not be null or empty");

        RuleFor(customer => customer.GenericName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Generic Name can not be null or empty");

        RuleFor(customer => customer.ProductionDate)
            .Must(date => date <= DateTime.UtcNow).WithMessage("Prodiction date must not be in future")
            .NotEmpty()
            .NotNull()
            .WithMessage("Production date can not be null or empty");

        RuleFor(customer => customer.ExpiredDate)
            .GreaterThan(d => d.ProductionDate).WithMessage("Expired date must be greater than Production date")
            .NotEmpty()
            .NotNull()
            .WithMessage("Expired date can not be null or empty");
    }
}