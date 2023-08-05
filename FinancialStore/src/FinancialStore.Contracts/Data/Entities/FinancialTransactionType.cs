namespace FinancialStore.Contracts.Data.Entities;
public class FinancialTransactionType:BaseEntity
{
    public FinancialTransactionType(int type, string description, NatureOperationType natureOperationType)
    {
        Type = type;
        Description = description;
        NatureOperationType = natureOperationType;
    }

    public int Type { get; private set; }
    public string Description { get; private set; }
    public NatureOperationType NatureOperationType { get; private set; }
}
