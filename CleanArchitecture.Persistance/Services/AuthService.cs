﻿using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Feature.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Feature.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Feature.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;
    public AuthService(UserManager<User> userManager, IMapper mapper, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null) throw new Exception("Kullanıcı bulunamadı!");

        if (user.RefreshToken != request.RefreshToken) throw new Exception("Refresh Token geçerli değil!");

        if (user.RefreshTokenExpires < DateTime.Now) throw new Exception("Refresh Token'ın süresi dolmuş!");

        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
        return response;
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {


        User? user = await _userManager.Users
            .Where(
                p => p.UserName == request.UserNameOrEmail
                    || p.Email == request.UserNameOrEmail)
            .FirstOrDefaultAsync(cancellationToken);


        if (user == null) throw new Exception("Kullanıcı Bulunamadı");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (result)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        throw new Exception("Şifreyi Yanlış girdiniz!");
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
