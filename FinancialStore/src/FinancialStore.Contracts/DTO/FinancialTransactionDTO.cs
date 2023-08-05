namespace FinancialStore.Contracts.DTO;

public record FinancialTransactionDTO
{
    public int Type { get; init; }
    public DateTime Date { get; private set; }
    public double Value { get; private set; }
    public string Cpf { get; private set; }
    public string CardNumber { get; private set; }
    public TimeSpan Hour { get; private set; }
    public string StoreOwner { get; private set; }
    public int StoreName { get; private set; }
}
