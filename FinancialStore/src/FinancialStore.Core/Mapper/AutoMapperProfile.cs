using AutoMapper;
using FinancialStore.Contracts.Data.Entities;
using FinancialStore.Contracts.DTO;

namespace FinancialStore.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FinancialTransaction, FinancialTransactionDTO>().ReverseMap();
        }
    }
}
