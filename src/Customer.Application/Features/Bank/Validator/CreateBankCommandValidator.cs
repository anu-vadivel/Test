using FluentValidation;
using Customer.Application.Features.Bank.Command;
using Customer.Persistence.Provider.Contract;

namespace Customer.Application.Features.Bank.Validator
{
    public class CreateBankCommandValidator : AbstractValidator<CreateBankCommand>
    {
        public CreateBankCommandValidator(IBankProvider bankProvider)
        {
            RuleFor(x => x.IfscCode)
                .NotEmpty()
                .Must(s => bankProvider.Bank(s).Result == null).WithMessage("Bank details already exists");
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}