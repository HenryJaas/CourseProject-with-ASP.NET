using CourseProject.Common.Dtos.Teams;
using FluentValidation;

namespace CourseProject.Business.Validation;

public class TeamCreateValidator : AbstractValidator<TeamCreate>
{
    public TeamCreateValidator()
    {
        RuleFor(teamCreate => teamCreate.Name).NotEmpty().MaximumLength(50);    
    }
}
