using Base.Domain.Enums;
using Datavanced.Applications.Actions.Doctors.Push;

namespace Datavanced.Applications.Actions.Doctors;

public class DoctorModel : BaseModel
{
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Degree { get; set; }
    public GenderEnum Gender { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public static DoctorModel Create(Doctor doctorEntity)
    {
        return new DoctorModel
        {
            Id = doctorEntity.Id,
            Name = doctorEntity.Name,
            Designation = doctorEntity.Designation,
            Degree = doctorEntity.Degree,
            Phone = doctorEntity.Phone,
            Email = doctorEntity.Email,
            Address = doctorEntity.Address,
            IsDeleted = doctorEntity.IsDeleted,
            Gender = doctorEntity.Gender
        };
    }

    public static DoctorModel CreateFromCommand(PushDoctorCommand doctorCommand)
    {
        return new DoctorModel
        {
            Id = doctorCommand.Id,
            Name = doctorCommand.Name,
            Designation = doctorCommand.Designation,
            Degree = doctorCommand.Degree,
            Phone = doctorCommand.Phone,
            Email = doctorCommand.Email,
            Address = doctorCommand.Address,
            IsDeleted = doctorCommand.IsDeleted,
            Gender = doctorCommand.Gender
        };
    }
}