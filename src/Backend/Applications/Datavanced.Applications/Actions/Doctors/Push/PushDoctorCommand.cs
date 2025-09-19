using Base.Domain.Enums;

namespace Datavanced.Applications.Actions.Doctors.Push;

public sealed class PushDoctorCommand : BaseModel, IRequest<PushResponse<DoctorModel>>
{
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Degree { get; set; }
    public GenderEnum Gender { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}