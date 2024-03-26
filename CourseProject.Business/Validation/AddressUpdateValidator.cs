using CourseProject.Common.Dtos.Address;
using FluentValidation;

namespace CourseProject.Business.Validation;

public class AddressUpdateValidator : AbstractValidator<AddressUpdate>
{
    public AddressUpdateValidator()
    {
        RuleFor(addressUpdate => addressUpdate.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(addressUpdate => addressUpdate.City).NotEmpty().MaximumLength(100);
        RuleFor(addressUpdate => addressUpdate.Street).NotEmpty().MaximumLength(100);
        RuleFor(addressUpdate => addressUpdate.Zip).NotEmpty().MaximumLength(20);
        RuleFor(addressUpdate => addressUpdate.Phone).MaximumLength(25);
    }
}
