using Base.Domain;

namespace Datavanced.Master.Domain.Entities;

public class Appointment : BaseEntity
{
    public DateTime AppoitmentDate { get; set; }
    public string Diagnosis { get; set; }
    public string VisitType { get; set; }
    public string Note { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}
