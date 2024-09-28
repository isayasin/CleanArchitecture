using CleanArchitecture.Application.Feature.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Feature.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Feature.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Prensentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Prensentation.Controllers;


public sealed class AuthController : ApiController
{
    private readonly IMailService _mailService;
    public AuthController(IMediator mediator, IMailService mailService) : base(mediator)
    {
        _mailService = mailService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromForm] RegisterCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);

        /*// Kayıt başarılı ise e-posta gönder
        if (response.Message == "Kullanıcı kaydı başarıyla tamamlandı")
        {
            var emailSubject = "Kaydın başarıyla gerçekleşti";
            var emailBody = "Hoşgeldin! KAydın başarı ile gerçekleşti.";

            // E-posta gönderme işlemi
            await _mailService.SendMailAsync(request.Email, emailSubject, emailBody, cancellationToken);
        }*/
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromForm] LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateTokenByRefreshToken([FromForm] CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}



