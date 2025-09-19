using Datavanced.Applications.Actions.Prescriptions.Push.CreatePrescription;

namespace Datavanced.Applications.Actions.Prescriptions;

public class PrescriptionModel : BaseModel
{
    public string Dosage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Notes { get; set; }
    public Guid MedicineId { get; set; }
    public Guid AppoitmentId { get; set; }

    public static PrescriptionModel Create(Prescription entity)
    {
        return new PrescriptionModel
        {
            Id = entity.Id,
            MedicineId = entity.MedicineId,
            AppoitmentId = entity.AppoitmentId,
            Dosage = entity.Dosage,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Notes = entity.Notes,
            IsDeleted = entity.IsDeleted
        };
    }

    public static PrescriptionModel CreateFromCommand(PushPrescriptionCommand command)
    {
        return new PrescriptionModel
        {
            Id = command.Id,
            MedicineId = command.MedicineId,
            AppoitmentId = command.AppoitmentId,
            Dosage = command.Dosage,
            StartDate = command.StartDate,
            EndDate = command.EndDate,
            Notes = command.Notes,
            IsDeleted = command.IsDeleted
        };
    }
}