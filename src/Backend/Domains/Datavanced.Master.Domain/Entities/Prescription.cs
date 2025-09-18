using Base.Domain;

namespace Datavanced.Master.Domain.Entities;

public class Prescription : BaseEntity
{
    public string Dosage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Notes { get; set; }
    public Guid MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public Guid AppoitmentId { get; set; }
    public Appointment Appoitment { get; set; }
}
