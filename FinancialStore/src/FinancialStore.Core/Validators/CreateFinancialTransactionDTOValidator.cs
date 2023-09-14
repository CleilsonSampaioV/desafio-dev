using FinancialStore.Contracts.DTO;
using FluentValidation;

namespace FinancialStore.Core.Validators;

public class CreateFinancialTransactionDTOValidator : AbstractValidator<FinancialTransactionDTO>
{
    public CreateFinancialTransactionDTOValidator()
    {
        RuleFor(x => x.Type).NotEmpty().GreaterThan(0).WithMessage("Type is required or greater than 0");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Type is required");
        RuleFor(x => x.Value).NotEmpty().WithMessage("Value is required");
        RuleFor(x => x.Cpf).NotEmpty().WithMessage("Cpf is required");
        RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Card Number is required");
        RuleFor(x => x.Hour).NotEmpty().Length(6).WithMessage("Hour must be with 6 numbers");
        RuleFor(x => x.StoreOwner).NotEmpty().WithMessage("Store owner is required");
        RuleFor(x => x.StoreName).NotEmpty().WithMessage("Store name is required");
    }
}