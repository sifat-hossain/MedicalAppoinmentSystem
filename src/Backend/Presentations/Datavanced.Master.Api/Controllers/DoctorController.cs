using Datavanced.Applications.Actions.Doctors;
using Datavanced.Applications.Actions.Doctors.Pull.PullDoctors;
using Datavanced.Applications.Actions.Doctors.Push;
using Datavanced.Applications.Services.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Datavanced.Master.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost()]
    public async Task<PushResponse<DoctorModel>> CreateDoctor(PushDoctorCommand command, CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet()]
    public async Task<PushResponse<DoctorModel>> PullDoctors(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new PullDoctorsRequest(), cancellationToken);
    }

}
