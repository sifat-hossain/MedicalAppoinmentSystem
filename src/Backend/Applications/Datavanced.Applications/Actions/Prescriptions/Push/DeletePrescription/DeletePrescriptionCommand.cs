namespace Datavanced.Applications.Actions.Prescriptions.Push.DeletePrescription;

public sealed class DeletePrescriptionCommand : IRequest<PushResponse>
{
    public Guid Id { get; set; }
}