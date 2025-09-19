namespace Datavanced.Applications.Actions.Doctors.Pull.PullDoctors;

public class PullDoctorsHandler : IRequestHandler<PullDoctorsRequest, PushResponse<DoctorModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PullDoctorsHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<DoctorModel>> Handle(PullDoctorsRequest request, CancellationToken cancellationToken)
    {
        try
        {

            List<Doctor> doctorQuery = await _coreDbContext.Doctor
                .Where(d => !d.IsDeleted)
                .AsNoTracking()
                .ToListAsync();

            if (doctorQuery.Count == 0)
            {
                return new PushResponse<DoctorModel>
                {
                    DidSucceed = true,
                    Models = new List<DoctorModel>()
                };
            }

            return new PushResponse<DoctorModel>
            {
                DidSucceed = true,
                Models = doctorQuery.Select(d => DoctorModel.Create(d)).ToList()
            };
        }
        catch (Exception ex)
        {
            return new PushResponse<DoctorModel>
            {
                DidSucceed = false,
                Message = string.Join(ex.Message, ex.InnerException?.Message)
            };
        }
    }
}