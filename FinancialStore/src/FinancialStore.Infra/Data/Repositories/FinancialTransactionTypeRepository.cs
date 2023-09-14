using FinancialStore.Contracts.Data.Entities;
using FinancialStore.Contracts.Data.Repositories;
using FinancialStore.Infra.Data.Repositories.Generic;
using FinancialStore.Migrations;

namespace FinancialStore.Infra.Data.Repositories
{
    public class FinancialTransactionTypeRepository : Repository<FinancialTransactionType>, IFinancialTransactionTypeRepository
    {
        private readonly DatabaseContext _databaseContext;
        public FinancialTransactionTypeRepository(DatabaseContext context) : base(context) 
        { 
            _databaseContext = context;
        }

        public FinancialTransactionType? GetByType(int type) => _databaseContext.FinancialTransactionTypes.Single(x => x.Type == type);
    }
}