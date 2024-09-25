using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Feature.CarFeatures.Queries.GetAllCar;
public sealed record GetAllCarQuery() : IRequest<IList<Car>>;
