using CourseProject.Common.Dtos.Employee;
using FluentValidation;

namespace CourseProject.Business.Validation;

public class EmployeeUpdateValidator : AbstractValidator<EmployeeUpdate>
{
    public EmployeeUpdateValidator()
    {
        RuleFor(employeeUpdate => employeeUpdate.FirstName).NotEmpty().MaximumLength(55);
        RuleFor(employeeUpdate => employeeUpdate.LastName).NotEmpty().MaximumLength(55);
      
    }
}
