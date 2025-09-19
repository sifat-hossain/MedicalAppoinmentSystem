namespace Datavanced.Applications.Actions.Patients.Push;

public sealed class PushPatientCommand : BaseModel, IRequest<PushResponse<PatientModel>>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int AgeType { get; set; }
    public int Gender { get; set; }
    public string Phone { get; set; }
    public string? Address { get; set; }
}