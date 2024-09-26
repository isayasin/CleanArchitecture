using AutoMapper;
using CleanArchitecture.Application.Feature.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Feature.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;

namespace CleanArchitecture.Persistance.Services;
public sealed class CarServices : ICarService
{
    private readonly AppDbContext _context;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CarServices(AppDbContext context, IMapper mapper, ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        //Car car = new()
        //{
        //    Name = request.Name,
        //    Model = request.Model,
        //    EnginePower = request.EnginePower,
        //};
        Car car = _mapper.Map<Car>(request);
        //await _context.Set<Car>().AddAsync(car, cancellationToken);
        //await _context.SaveChangesAsync(cancellationToken);

        await _carRepository.AddAsync(car, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> cars = await _carRepository.Where(p => p.Name.ToLower().Contains(request.Search.ToLower())).ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return cars;
    }
}
