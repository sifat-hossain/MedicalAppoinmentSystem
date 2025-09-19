namespace Datavanced.Applications.Actions.Prescriptions.Push.CreatePrescription;

public sealed class PushPrescriptionHandler : IRequestHandler<PushPrescriptionCommand, PushResponse<PrescriptionModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PushPrescriptionHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<PrescriptionModel>> Handle(PushPrescriptionCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var prescription = new Prescription
            {
                Id = command.Id,
                Dosage = command.Dosage,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                Notes = command.Notes,
                MedicineId = command.MedicineId,
                AppoitmentId = command.AppoitmentId,
                IsDeleted = command.IsDeleted
            };

            await _coreDbContext.Prescription.AddAsync(prescription, cancellationToken);
            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse<PrescriptionModel>
            {
                DidSucceed = true,
                Model = PrescriptionModel.CreateFromCommand(command),
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