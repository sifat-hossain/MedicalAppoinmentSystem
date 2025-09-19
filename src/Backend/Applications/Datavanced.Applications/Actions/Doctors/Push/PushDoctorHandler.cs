namespace Datavanced.Applications.Actions.Doctors.Push;

public sealed class PushDoctorHandler : IRequestHandler<PushDoctorCommand, PushResponse<DoctorModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PushDoctorHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<DoctorModel>> Handle(PushDoctorCommand command, CancellationToken cancellationToken)
    {
        try
        {

            Doctor? doctor = await _coreDbContext.Doctor
                .SingleOrDefaultAsync(d => d.Id == command.Id && !d.IsDeleted, cancellationToken);

            if (doctor == null)
            {
                doctor = new Doctor
                {
                    Id = Guid.NewGuid(),
                };
                _coreDbContext.Doctor.Add(doctor);
            }
            doctor.Name = command.Name;
            doctor.Designation = command.Designation;
            doctor.Degree = command.Degree;
            doctor.IsDeleted = command.IsDeleted;
            doctor.Address = command.Address;
            doctor.Email = command.Email;
            doctor.Phone = command.Phone;

            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse<DoctorModel>
            {
                DidSucceed = true,
                Model = DoctorModel.CreateFromCommand(command),
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