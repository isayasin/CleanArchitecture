using CleanArchitecture.Application.Feature.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Feature.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;
public interface ICarService
{
    Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
    Task<IList<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);
}
