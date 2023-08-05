namespace FinancialStore.Contracts.Data.Entities;

public class FinancialTransaction : BaseEntity
{
    public FinancialTransaction(FinancialTransactionType type, DateTime date, double value, string cpf, string cardNumber, TimeSpan hour, string storeOwner, string storeName)
    {
        Type = type;
        Date = date;
        Value = value;
        Cpf = cpf;
        CardNumber = cardNumber;
        Hour = hour;
        StoreOwner = storeOwner;
        StoreName = storeName;
    }

    public FinancialTransactionType Type { get; private set; }
    public DateTime Date { get; private set; }
    public double Value { get; private set; }
    public string Cpf { get; private set; }
    public string CardNumber { get; private set; }
    public TimeSpan Hour { get; private set; }
    public string StoreOwner { get; private set; }
    public string StoreName { get; private set; }
}
