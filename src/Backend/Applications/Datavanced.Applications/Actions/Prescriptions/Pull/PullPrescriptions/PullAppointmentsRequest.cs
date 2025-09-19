using Datavanced.Applications.Actions.Prescriptions;

namespace Datavanced.Applications.Actions.Prescriptions.Pull.PullPrescriptions;

public class PullPrescriptionsRequest : IRequest<PushResponse<PrescriptionModel>>
{
    public Guid? AppointmentId { get; set; }
}