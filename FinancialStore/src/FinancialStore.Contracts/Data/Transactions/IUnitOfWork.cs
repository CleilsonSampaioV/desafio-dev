using FinancialStore.Contracts.Data.Repositories;

namespace FinancialStore.Contracts.Data.Transactions;

public interface IUnitOfWork
{
    IFinancialTransactionRepository FinancialTransactionRepository { get; }
    IFinancialTransactionTypeRepository FinancialTransactionTypeRepository { get; }
    Task CommitAsync();
}
