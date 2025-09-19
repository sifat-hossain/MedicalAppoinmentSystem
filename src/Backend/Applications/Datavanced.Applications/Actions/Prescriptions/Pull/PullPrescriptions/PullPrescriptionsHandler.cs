namespace Datavanced.Applications.Actions.Prescriptions.Pull.PullPrescriptions;

public class PullPrescriptionsHandler : IRequestHandler<PullPrescriptionsRequest, PushResponse<PrescriptionModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PullPrescriptionsHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<PrescriptionModel>> Handle(PullPrescriptionsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<Prescription> prescriptionQuery = await _coreDbContext.Prescription
                .Where(d => !d.IsDeleted)
                .Include(d => d.Appoitment)
                .Include(d => d.Medicine)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            return new PushResponse<PrescriptionModel>
            {
                DidSucceed = true,
                Models = prescriptionQuery.Select(d => PrescriptionModel.Create(d)).ToList()
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