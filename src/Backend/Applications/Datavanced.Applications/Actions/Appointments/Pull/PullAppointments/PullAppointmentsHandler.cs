using Base.Domain.Constants;

namespace Datavanced.Applications.Actions.Appointments.Pull.PullAppointments;

public class PullAppointmentsHandler : IRequestHandler<PullAppointmentsRequest, PushResponse<AppointmentModel>>
{
    private readonly IDatavancedMedicalDbContext _coreDbContext;

    public PullAppointmentsHandler(IDatavancedMedicalDbContext coreDbContext)
    {
        _coreDbContext = coreDbContext;
    }

    public async Task<PushResponse<AppointmentModel>> Handle(PullAppointmentsRequest request, CancellationToken cancellationToken)
    {
        try
        {

            int take = request.Take <= 0 ? Constants.FieldSize.PageSize : request.Take;

            IQueryable<Appointment> appointmentQuery = _coreDbContext.Appointment
                .Include(d => d.Doctor)
                .Include(d => d.Patient)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchText))
            {
                appointmentQuery = appointmentQuery.Where(d => d.Doctor.Name.Contains(request.SearchText) ||
                     d.Patient.Name.Contains(request.SearchText));
            }

            if (request.DoctorId.HasValue && request.DoctorId != Guid.Empty)
            {
                appointmentQuery = appointmentQuery.Where(d => d.DoctorId == request.DoctorId);
            }

            if (!string.IsNullOrWhiteSpace(request.VisitType))
            {
                appointmentQuery = appointmentQuery.Where(d => d.VisitType == request.VisitType);
            }

            appointmentQuery = appointmentQuery.Skip(request.Skip).Take(take);

            return new PushResponse<AppointmentModel>
            {
                DidSucceed = true,
                Models = appointmentQuery.Select(d => AppointmentModel.Create(d)).ToList()
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