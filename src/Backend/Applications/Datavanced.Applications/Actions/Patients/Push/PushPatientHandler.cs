using Base.Domain.Enums;

namespace Datavanced.Applications.Actions.Patients.Push;

public sealed class PushPatientHandler : IRequestHandler<PushPatientCommand, PushResponse<PatientModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PushPatientHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<PatientModel>> Handle(PushPatientCommand command, CancellationToken cancellationToken)
    {
        try
        {

            Patient? patient = await _coreDbContext.Patient
                .SingleOrDefaultAsync(d => d.Id == command.Id && !d.IsDeleted, cancellationToken);

            if (patient == null)
            {
                patient = new Patient
                {
                    Id = Guid.NewGuid(),
                };
                _coreDbContext.Patient.Add(patient);
            }
            patient.Name = command.Name;
            patient.Age = command.Age;
            patient.AgeType = (AgeTypeEnum)command.AgeType;
            patient.IsDeleted = command.IsDeleted;
            patient.Address = command.Address;
            patient.Phone = command.Phone;
            patient.Gender = (GenderEnum)command.Gender;

            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse<PatientModel>
            {
                DidSucceed = true,
                Model = PatientModel.CreateFromCommand(command),
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