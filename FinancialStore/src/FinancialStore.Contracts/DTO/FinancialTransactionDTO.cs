namespace FinancialStore.Contracts.DTO;

public record FinancialTransactionDTO
{
    public int Type { get; init; }
    public string Date { get; init; }
    public string Value { get; init; }
    public string Cpf { get; init; }
    public string CardNumber { get; init; }
    public string Hour { get; init; }
    public string StoreOwner { get; init; }
    public string StoreName { get; init; }
}