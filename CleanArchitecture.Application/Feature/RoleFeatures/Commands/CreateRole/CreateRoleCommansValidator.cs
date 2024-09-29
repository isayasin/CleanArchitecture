using FluentValidation;

namespace CleanArchitecture.Application.Feature.RoleFeatures.Commands.CreateRole;
public sealed class CreateRoleCommansValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommansValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Rol adı alanı boş olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Rol adı alanı boş olamaz!");
    }
}
