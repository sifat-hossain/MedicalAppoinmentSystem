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
            var appointment = await _coreDbContext.Appointment
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
            if (appointment == null)
            {
                appointment = new Appointment
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.UtcNow,
                };
                await _coreDbContext.Appointment.AddAsync(appointment, cancellationToken);
            }

            appointment.AppoitmentDate = command.AppoitmentDate;
            appointment.Diagnosis = command.Diagnosis;
            appointment.VisitType = command.VisitType;
            appointment.IsDeleted = command.IsDeleted;
            appointment.Note = command.Note;
            appointment.PatientId = command.PatientId;
            appointment.DoctorId = command.DoctorId;

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