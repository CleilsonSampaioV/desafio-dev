using FinancialStore.Contracts.Data.Repositories;

namespace FinancialStore.Contracts.Data.Transactions;

public interface IUnitOfWork
{
    IFinancialTransactionRepository FinancialTransactionRepository { get; }
    Task CommitAsync();
}
