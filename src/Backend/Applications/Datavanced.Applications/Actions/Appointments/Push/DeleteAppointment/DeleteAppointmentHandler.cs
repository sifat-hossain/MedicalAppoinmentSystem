namespace Datavanced.Applications.Actions.Appointments.Push.DeleteAppointment;

public sealed class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentCommand, PushResponse>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public DeleteAppointmentHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse> Handle(DeleteAppointmentCommand command, CancellationToken cancellationToken)
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

            appointment.IsDeleted = true;

            _coreDbContext.Appointment.Update(appointment);
            await _coreDbContext.SaveChangesAsync(cancellationToken);

            return new PushResponse
            {
                DidSucceed = true,
                Message = "Appointment has been successfully deleted"
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