using Base.Domain;

namespace Datavanced.Master.Domain.Entities;

public class Medicine : BaseEntity
{
    public string Name { get; set; }
    public string GenericName { get; set; }
    public string Description { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiredDate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
}
