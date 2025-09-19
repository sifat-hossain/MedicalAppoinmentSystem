namespace Datavanced.Applications.Actions.Appointments.Pull.PullAppointments;

public class PullAppointmentsRequest : IRequest<PushResponse<AppointmentModel>>
{
    public string? SearchText { get; set; }
    public Guid? DoctorId { get; set; }
    public string? VisitType { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}