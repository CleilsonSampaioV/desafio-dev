using AutoMapper;
using FinancialStore.Contracts.Data.Transactions;
using FinancialStore.Contracts.DTO;
using System.Linq;
using MediatR;
using FinancialStore.Contracts.Data.Entities;

namespace FinancialStore.Core.Queries
{
    public class GetAllFinancialTransactionQuery : IRequest<IEnumerable<FinancialTransactionSummaryDTO>>
    {
    }

    public class GetAllFinancialTransactionQueryHandler : IRequestHandler<GetAllFinancialTransactionQuery, IEnumerable<FinancialTransactionSummaryDTO>>
    {
        private readonly IUnitOfWork _repository;

        public GetAllFinancialTransactionQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FinancialTransactionSummaryDTO>> Handle(GetAllFinancialTransactionQuery request, CancellationToken cancellationToken)
        {
            var financialTransactionSummaryDTOList = new List<FinancialTransactionSummaryDTO>();
            var entities = _repository.FinancialTransactionRepository.GetAllWithFinancialTransactionType().GroupBy(x => x.StoreName).ToList();

            foreach (var stores in entities)
            {
                var incomes = stores.Where(x=>x.FinancialTransactionType.Type == (int)NatureOperationType.Income).Sum(x=>x.Value);
                var expenses = stores.Where(x => x.FinancialTransactionType.Type == (int)NatureOperationType.Expense).Sum(x => x.Value);

                var financialTransactionSummary = new FinancialTransactionSummaryDTO
                {
                    StoreName = stores.Key,
                    Value = incomes - incomes
                };
                financialTransactionSummaryDTOList.Add(financialTransactionSummary);
            }

            return financialTransactionSummaryDTOList;
        }
    }
}