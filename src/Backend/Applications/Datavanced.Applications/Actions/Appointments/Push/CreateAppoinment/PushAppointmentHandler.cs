namespace Datavanced.Applications.Actions.Appointments.Push.CreateAppoinment;

public sealed class PushAppointmentHandler : IRequestHandler<PushAppointmentCommand, PushResponse<AppointmentModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PushAppointmentHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<AppointmentModel>> Handle(PushAppointmentCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var appointment = new Appointment
            {
                Id = command.Id,
                AppoitmentDate = command.AppoitmentDate,
                Diagnosis = command.Diagnosis,
                VisitType = command.VisitType,
                IsDeleted = command.IsDeleted,
                Note = command.Note,
                PatientId = command.PatientId,
                DoctorId = command.DoctorId
            };

            await _coreDbContext.Appointment.AddAsync(appointment, cancellationToken);
            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse<AppointmentModel>
            {
                DidSucceed = true,
                Model = AppointmentModel.CreateFromCommand(command),
            };
        }
        catch (Exception ex)
        {

            return new PushResponse<AppointmentModel>
            {
                DidSucceed = false,
                Message = string.Join(ex.Message, ex.InnerException?.Message)

            };
        }
    }
}