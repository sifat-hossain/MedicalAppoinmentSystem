using Datavanced.Applications.Actions.Medicines;
using Datavanced.Applications.Actions.Medicines.Pull.PullMedicines;
using Datavanced.Applications.Actions.Medicines.Push;
using Datavanced.Applications.Services.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Datavanced.Master.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicineController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost()]
    public async Task<PushResponse<MedicineModel>> CreateMedicine(PushMedicineCommand command, CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet()]
    public async Task<PushResponse<MedicineModel>> PullMedicines(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new PullMedicinesRequest(), cancellationToken);
    }
}
