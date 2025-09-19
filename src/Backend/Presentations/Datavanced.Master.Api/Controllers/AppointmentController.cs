using Datavanced.Applications.Actions.Appointments;
using Datavanced.Applications.Actions.Appointments.Pull.PullAppointments;
using Datavanced.Applications.Actions.Appointments.Push.CreateAppoinment;
using Datavanced.Applications.Actions.Appointments.Push.DeleteAppointment;
using Datavanced.Applications.Actions.Appointments.Push.UpdateAppointment;
using Datavanced.Applications.Services.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Datavanced.Master.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost()]
    public async Task<PushResponse<AppointmentModel>> CreateAppointment(PushAppointmentCommand command, CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet()]
    public async Task<PushResponse<AppointmentModel>> PullAppointments(PullAppointmentsRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<PushResponse<AppointmentModel>> UpdateAppointment(Guid id, UpdateAppointmentCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<PushResponse> DeleteAppointment(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteAppointmentCommand { Id = id }, cancellationToken);
    }
}
