namespace FinancialStore.Contracts.Data.Entities;

public class FinancialTransactionType : BaseEntity
{
    public int Type { get; set; }
    public string Description { get; set; }
    public NatureOperationType NatureOperationType { get; set; }
    public IEnumerable<FinancialTransaction> FinancialTransactions { get; set; }
}
