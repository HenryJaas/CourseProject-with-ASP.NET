using CourseProject.Common.Dtos.Job;
using FluentValidation;

namespace CourseProject.Business.Validation;

public class JobUpdateValidator : AbstractValidator<JobUpdate>
{
    public JobUpdateValidator()
    {
        RuleFor(jobUpdate => jobUpdate.Name).NotEmpty().MaximumLength(55);
        RuleFor(jobUpdate => jobUpdate.Description).NotEmpty().MaximumLength(255);
      
    }
}
