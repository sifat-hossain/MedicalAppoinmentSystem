using Base.Domain.Enums;
using Datavanced.Applications.Actions.Patients.Push;

namespace Datavanced.Applications.Actions.Patients;

public class PatientModel : BaseModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public AgeTypeEnum AgeType { get; set; }
    public GenderEnum Gender { get; set; }
    public string Phone { get; set; }
    public string? Address { get; set; }

    public static PatientModel Create(Patient entity)
    {
        return new PatientModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Age = entity.Age,
            AgeType = entity.AgeType,
            Phone = entity.Phone,
            Address = entity.Address,
            IsDeleted = entity.IsDeleted,
            Gender = entity.Gender
        };
    }

    public static PatientModel CreateFromCommand(PushPatientCommand command)
    {
        return new PatientModel
        {
            Id = command.Id,
            Name = command.Name,
            Age = command.Age,
            AgeType = (AgeTypeEnum)command.AgeType,
            Phone = command.Phone,
            Address = command.Address,
            IsDeleted = command.IsDeleted,
            Gender = (GenderEnum)command.Gender
        };
    }
}