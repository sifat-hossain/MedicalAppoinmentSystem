using Datavanced.Applications.Actions.Patients;
using Datavanced.Applications.Actions.Patients.Pull.PullPatients;
using Datavanced.Applications.Actions.Patients.Push;
using Datavanced.Applications.Services.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Datavanced.Master.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost()]
    public async Task<PushResponse<PatientModel>> CreatePatient(PushPatientCommand command, CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet()]
    public async Task<PushResponse<PatientModel>> PullMedicines(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new PullPatientsRequest(), cancellationToken);
    }
}
