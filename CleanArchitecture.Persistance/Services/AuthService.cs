using AutoMapper;
using CleanArchitecture.Application.Feature.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistance.Services;
public sealed class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public AuthService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task RegisterAsync(RegisterCommand request)
    {
        User user = _mapper.Map<User>(request);

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
            throw new Exception($"Kayıt işlemi başarısız oldu: {errors}");
        }
    }
}
