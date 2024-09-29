using CleanArchitecture.Application.Feature.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Prensentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Prensentation.Controllers;
public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromForm] CreateRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
