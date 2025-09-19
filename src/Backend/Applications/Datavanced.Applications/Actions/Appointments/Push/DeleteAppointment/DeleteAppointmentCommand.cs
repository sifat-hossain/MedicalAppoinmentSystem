namespace Datavanced.Applications.Actions.Appointments.Push.DeleteAppointment;

public sealed class DeleteAppointmentCommand : IRequest<PushResponse>
{
    public Guid Id { get; set; }
}