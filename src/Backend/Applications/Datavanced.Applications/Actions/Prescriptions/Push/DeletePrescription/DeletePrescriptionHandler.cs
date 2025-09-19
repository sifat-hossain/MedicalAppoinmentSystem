namespace Datavanced.Applications.Actions.Prescriptions.Push.DeletePrescription;

public sealed class DeletePrescriptionHandler : IRequestHandler<DeletePrescriptionCommand, PushResponse>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public DeletePrescriptionHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse> Handle(DeletePrescriptionCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Prescription? prescription = await _coreDbContext.Prescription
                .SingleOrDefaultAsync(d => d.Id == command.Id && !d.IsDeleted, cancellationToken);

            if (prescription == null)
            {
                return new PushResponse<PrescriptionModel>
                {
                    DidSucceed = false,
                    Message = $"Prescription not found with id {command.Id}"
                };
            }

            prescription.IsDeleted = true;

            _coreDbContext.Prescription.Update(prescription);
            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse
            {
                DidSucceed = true,
                Message = "Prescription has been successfully deleted"
            };
        }
        catch (Exception ex)
        {

            return new PushResponse<PrescriptionModel>
            {
                DidSucceed = false,
                Message = string.Join(ex.Message, ex.InnerException?.Message)
            };
        }
    }
}