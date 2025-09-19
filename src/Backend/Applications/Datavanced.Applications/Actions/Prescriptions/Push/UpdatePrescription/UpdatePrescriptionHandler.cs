namespace Datavanced.Applications.Actions.Prescriptions.Push.UpdatePrescription;

public sealed class UpdatePrescriptionHandler : IRequestHandler<UpdatePrescriptionCommand, PushResponse<PrescriptionModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public UpdatePrescriptionHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<PrescriptionModel>> Handle(UpdatePrescriptionCommand command, CancellationToken cancellationToken)
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

            prescription.Dosage = command.Dosage;
            prescription.StartDate = command.StartDate;
            prescription.EndDate = command.EndDate;
            prescription.IsDeleted = command.IsDeleted;
            prescription.Notes = command.Notes;
            prescription.MedicineId = command.MedicineId;
            prescription.AppoitmentId = command.AppoitmentId;

            _coreDbContext.Prescription.Update(prescription);
            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse<PrescriptionModel>
            {
                DidSucceed = true,
                Model = PrescriptionModel.Create(prescription),
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