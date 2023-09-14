using FinancialStore.Contracts.Data.Entities;

namespace FinancialStore.Contracts.Data.Repositories;

public interface IFinancialTransactionRepository : IBaseRepository<FinancialTransaction>
{
    IEnumerable<FinancialTransaction> GetAllWithFinancialTransactionType();
}
