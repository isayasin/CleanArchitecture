using FluentValidation;

namespace CleanArchitecture.Application.Feature.AuthFeatures.Commands.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı ya da mail alanı boş olamaz!");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı ya da mail alanı boş olamaz!");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre alanı boş olamaz!");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre alanı boş olamaz!");

    }
}
