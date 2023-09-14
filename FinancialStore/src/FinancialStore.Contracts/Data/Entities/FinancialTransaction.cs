namespace FinancialStore.Contracts.Data.Entities;

public class FinancialTransaction : BaseEntity
{
    public DateTime Date { get;  set; }
    public double Value { get;  set; }
    public string Cpf { get;  set; }
    public string CardNumber { get;  set; }
    public TimeSpan Hour { get;  set; }
    public string StoreOwner { get;  set; }
    public string StoreName { get;  set; }

    public Guid FinancialTransactionTypeId { get; set; }
    public FinancialTransactionType FinancialTransactionType { get; set; }
}
