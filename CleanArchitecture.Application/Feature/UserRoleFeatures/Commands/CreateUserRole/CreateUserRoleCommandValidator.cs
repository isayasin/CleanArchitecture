using FluentValidation;

namespace CleanArchitecture.Application.Feature.UserRoleFeatures.Commands.CreateUserRole;
public sealed class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("Kullanıcı bilgisi boş olamaz!");
        RuleFor(p => p.UserId).NotNull().WithMessage("Kullanıcı bilgisi boş olamaz!");

        RuleFor(p => p.RoleId).NotEmpty().WithMessage("Rol bilgisi boş olamaz!");
        RuleFor(p => p.RoleId).NotNull().WithMessage("Rol bilgisi boş olamaz!");
    }
}
