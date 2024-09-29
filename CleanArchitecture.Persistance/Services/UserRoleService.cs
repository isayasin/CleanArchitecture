using AutoMapper;
using CleanArchitecture.Application.Feature.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;

namespace CleanArchitecture.Persistance.Services;
public sealed class UserRoleService : IUserRoleService
{

    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRoleRepository = userRoleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole userRole = _mapper.Map<UserRole>(request);

        await _userRoleRepository.AddAsync(userRole);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
