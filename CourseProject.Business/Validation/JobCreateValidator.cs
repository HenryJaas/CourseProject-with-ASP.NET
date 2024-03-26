using CourseProject.Common.Dtos.Job;
using FluentValidation;

namespace CourseProject.Business.Validation;

public class JobCreateValidator : AbstractValidator<JobCreate>
{
    public JobCreateValidator()
    {
        RuleFor(jobCreate => jobCreate.Name).NotEmpty().MaximumLength(55);
        RuleFor(jobCreate => jobCreate.Description).NotEmpty().MaximumLength(255);
      
    }
}
