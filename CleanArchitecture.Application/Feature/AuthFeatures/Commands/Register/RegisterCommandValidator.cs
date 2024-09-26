using FluentValidation;

namespace CleanArchitecture.Application.Feature.AuthFeatures.Commands.Register;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.Email).NotEmpty().WithMessage("Mail alanı boş olamaz!");
        RuleFor(p => p.Email).NotNull().WithMessage("Mail alanı boş olamaz!");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi girin!");

        RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş olamaz!");
        RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı adı alanı boş olamaz!");
        RuleFor(p => p.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır!");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre alanı boş olamaz!");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre alanı boş olamaz!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az 1 adet Büyük harf içermelidir");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az 1 adet Küçük harf içermelidir");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az 1 adet Rakam içermelidir");
        RuleFor(p => p.Password).Matches("[^a-aA-Z0-9]").WithMessage("Şifre en az 1 adet Özel karakter içermelidir");
    }
}
