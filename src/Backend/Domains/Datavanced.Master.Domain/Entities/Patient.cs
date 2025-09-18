using Base.Domain;
using Base.Domain.Enums;

namespace Datavanced.Master.Domain.Entities;

public class Patient : BaseEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public AgeTypeEnum AgeType { get; set; }
    public GenderEnum Gender { get; set; }
    public string Phone { get; set; }
    public string? Address { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
}
