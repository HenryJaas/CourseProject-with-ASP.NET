using CourseProject.Common.Dtos.Teams;
using FluentValidation;

namespace CourseProject.Business.Validation;

public class TeamUpdateValidator : AbstractValidator<TeamUpdate>
{
    public TeamUpdateValidator()
    {
        RuleFor(teamUpdate => teamUpdate.Name).NotEmpty().MaximumLength(50);     
    }
}
