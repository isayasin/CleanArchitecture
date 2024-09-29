﻿using CleanArchitecture.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authorization;
public sealed class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;
    private readonly IUserRoleRepository _userRoleRepository;

    public RoleAttribute(string role, IUserRoleRepository roleRepository)
    {
        _role = role;
        _userRoleRepository = roleRepository;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        //Kullanıcının JWT token'ında veya kimlik bilgilerinde saklanan userId değerini alır. Bu değer, kullanıcıyı sistemde tanımlamak için kullanılır.

        if (userIdClaim == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userHasRole = _userRoleRepository
            .Where(p => p.UserId == userIdClaim.Value)
            .Include(p => p.Role)
            .Any(p => p.Role.Name == _role);

        if (!userHasRole)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
