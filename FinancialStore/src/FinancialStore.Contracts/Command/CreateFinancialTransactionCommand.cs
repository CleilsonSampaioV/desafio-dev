using FinancialStore.Contracts.DTO;
using MediatR;

public record CreateFinancialTransactionCommand : IRequest<BaseCommandResult>
{
    public IReadOnlyCollection<FinancialTransactionDTO> Models { get; }
    public CreateFinancialTransactionCommand(IReadOnlyCollection<FinancialTransactionDTO> model)
    {
        this.Models = model;
    }
}
