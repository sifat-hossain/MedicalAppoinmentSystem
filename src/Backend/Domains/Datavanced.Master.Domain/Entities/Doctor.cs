using Base.Domain;
using Base.Domain.Enums;

namespace Datavanced.Master.Domain.Entities;

public class Doctor : BaseEntity
{
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Degree { get; set; }
    public GenderEnum Gender { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
}
