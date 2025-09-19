namespace Datavanced.Applications.Actions.Appointments.Push.UpdateAppointment;

public sealed class UpdateAppointmentHandler : IRequestHandler<UpdateAppointmentCommand, PushResponse<AppointmentModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public UpdateAppointmentHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<AppointmentModel>> Handle(UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Appointment? appointment = await _coreDbContext.Appointment
                .SingleOrDefaultAsync(d => d.Id == command.Id && !d.IsDeleted, cancellationToken);

            if (appointment == null)
            {
                return new PushResponse<AppointmentModel>
                {
                    DidSucceed = false,
                    Message = $"Appointment not found with id {command.Id}"
                };
            }

            appointment.AppoitmentDate = command.AppoitmentDate;
            appointment.Diagnosis = command.Diagnosis;
            appointment.VisitType = command.VisitType;
            appointment.IsDeleted = command.IsDeleted;
            appointment.Note = command.Note;
            appointment.PatientId = command.PatientId;
            appointment.DoctorId = command.DoctorId;

            _coreDbContext.Appointment.Update(appointment);
            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse<AppointmentModel>
            {
                DidSucceed = true,
                Model = AppointmentModel.Create(appointment),
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