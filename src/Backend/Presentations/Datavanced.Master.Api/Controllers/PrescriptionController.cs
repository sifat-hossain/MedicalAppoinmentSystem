using Datavanced.Applications.Actions.Prescriptions;
using Datavanced.Applications.Actions.Prescriptions.Pull.PullPrescriptions;
using Datavanced.Applications.Actions.Prescriptions.Push.CreatePrescription;
using Datavanced.Applications.Actions.Prescriptions.Push.DeletePrescription;
using Datavanced.Applications.Actions.Prescriptions.Push.UpdatePrescription;
using Datavanced.Applications.Services.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Datavanced.Master.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost()]
    public async Task<PushResponse<PrescriptionModel>> CreatePrescription(PushPrescriptionCommand command, CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet()]
    public async Task<PushResponse<PrescriptionModel>> PullPrescriptions([FromQuery] Guid appointmentId, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new PullPrescriptionsRequest { AppointmentId = appointmentId }, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<PushResponse<PrescriptionModel>> UpdatePrescription(Guid id, UpdatePrescriptionCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<PushResponse> DeletePrescription(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeletePrescriptionCommand { Id = id }, cancellationToken);
    }
}
