using Datavanced.Applications.Actions.Appointments.Push.CreateAppoinment;

namespace Datavanced.Applications.Actions.Appointments;

public class AppointmentModel : BaseModel
{
    public DateTime AppoitmentDate { get; set; }
    public string Diagnosis { get; set; }
    public string VisitType { get; set; }
    public string Note { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }

    public static AppointmentModel Create(Appointment entity)
    {
        return new AppointmentModel
        {
            Id = entity.Id,
            AppoitmentDate = entity.AppoitmentDate,
            Diagnosis = entity.Diagnosis,
            VisitType = entity.VisitType,
            Note = entity.Note,
            PatientId = entity.PatientId,
            DoctorId = entity.DoctorId,
            IsDeleted = entity.IsDeleted
        };
    }

    public static AppointmentModel CreateFromCommand(PushAppointmentCommand command)
    {
        return new AppointmentModel
        {
            Id = command.Id,
            AppoitmentDate = command.AppoitmentDate,
            Diagnosis = command.Diagnosis,
            VisitType = command.VisitType,
            Note = command.Note,
            PatientId = command.PatientId,
            DoctorId = command.DoctorId,
            IsDeleted = command.IsDeleted
        };
    }
}