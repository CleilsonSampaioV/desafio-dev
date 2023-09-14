using FinancialStore.Contracts.Data.Entities;

namespace FinancialStore.Contracts.Data.Repositories;

public interface IFinancialTransactionTypeRepository : IBaseRepository<FinancialTransactionType>
{
    FinancialTransactionType GetByType(int type);
}
