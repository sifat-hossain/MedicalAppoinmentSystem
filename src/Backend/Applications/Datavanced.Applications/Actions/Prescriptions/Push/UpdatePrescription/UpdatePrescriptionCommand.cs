namespace Datavanced.Applications.Actions.Prescriptions.Push.UpdatePrescription;

public sealed class UpdatePrescriptionCommand : BaseModel, IRequest<PushResponse<PrescriptionModel>>
{
    public string Dosage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Notes { get; set; }
    public Guid MedicineId { get; set; }
    public Guid AppoitmentId { get; set; }
}