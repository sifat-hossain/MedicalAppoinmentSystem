namespace Datavanced.Applications.Actions.Patients.Pull.PullPatients;

public class PullPatientsHandler : IRequestHandler<PullPatientsRequest, PushResponse<PatientModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PullPatientsHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<PatientModel>> Handle(PullPatientsRequest request, CancellationToken cancellationToken)
    {
        try
        {

            List<Patient> patientQuery = await _coreDbContext.Patient
                .Where(d => !d.IsDeleted)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            if (patientQuery.Count == 0)
            {
                return new PushResponse<PatientModel>
                {
                    DidSucceed = true,
                    Models = new List<PatientModel>()
                };
            }

            return new PushResponse<PatientModel>
            {
                DidSucceed = true,
                Models = patientQuery.Select(d => PatientModel.Create(d)).ToList()
            };
        }
        catch (Exception ex)
        {
            return new PushResponse<PatientModel>
            {
                DidSucceed = false,
                Message = string.Join(ex.Message, ex.InnerException?.Message)
            };
        }
    }
}