using FluentValidation;

namespace CleanArchitecture.Application.Feature.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
public class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User alanı boş olamaz.");
        RuleFor(p => p.UserId).NotNull().WithMessage("User alanı boş olamaz.");
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Refresh Token alanı boş olamaz.");
        RuleFor(p => p.RefreshToken).NotNull().WithMessage("Refresh Token alanı boş olamaz.");
    }
}
