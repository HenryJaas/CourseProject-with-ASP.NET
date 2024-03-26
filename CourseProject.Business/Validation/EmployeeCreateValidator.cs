using CourseProject.Common.Dtos.Employee;
using FluentValidation;

namespace CourseProject.Business.Validation;

public class EmployeeCreateValidator : AbstractValidator<EmployeeCreate>
{
    public EmployeeCreateValidator()
    {
        RuleFor(employeeCreate => employeeCreate.FirstName).NotEmpty().MaximumLength(55);
        RuleFor(employeeCreate => employeeCreate.LastName).NotEmpty().MaximumLength(55);
      
    }
}
