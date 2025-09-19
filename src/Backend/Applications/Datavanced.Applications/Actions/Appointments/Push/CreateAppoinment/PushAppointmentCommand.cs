namespace Datavanced.Applications.Actions.Appointments.Push.CreateAppoinment;

public sealed class PushAppointmentCommand : BaseModel, IRequest<PushResponse<AppointmentModel>>
{
    public DateTime AppoitmentDate { get; set; }
    public string Diagnosis { get; set; }
    public string VisitType { get; set; }
    public string Note { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
}