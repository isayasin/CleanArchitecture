using CleanArchitecture.Application.Feature.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Feature.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Prensentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Prensentation.Controllers;
public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCarCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        IList<Car> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
