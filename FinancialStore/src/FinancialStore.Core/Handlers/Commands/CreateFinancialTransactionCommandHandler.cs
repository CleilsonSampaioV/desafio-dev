using FinancialStore.Contracts.Data.Entities;
using FinancialStore.Contracts.Data.Transactions;
using FinancialStore.Contracts.DTO;
using FinancialStore.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace FinancialStore.Core.Handlers.Commands
{
    public class CreateFinancialTransactionCommandHandler : IRequestHandler<CreateFinancialTransactionCommand, BaseCommandResult>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<FinancialTransactionDTO> _validator;
        public CreateFinancialTransactionCommandHandler(
            IUnitOfWork repository, IValidator<FinancialTransactionDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }



        public async Task<BaseCommandResult> Handle(CreateFinancialTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var listFinancialTransaction = new List<FinancialTransaction>();

                foreach (var model in request.Models)
                {
                    var result = _validator.Validate(model);

                    if (!result.IsValid)
                    {
                        var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                        throw new InvalidRequestBodyException
                        {
                            Errors = errors
                        };
                    }

                    var financialTransactionType = _repository.FinancialTransactionTypeRepository.GetByType(model.Type);

                    listFinancialTransaction.Add(
                        new FinancialTransaction
                        {
                            //FinancialTransactionTypeId = financialTransactionType.Id,
                            Date = GetNomalizedDate(model.Date),
                            Value = GetNomalizedValue(model.Value),
                            Cpf = model.Cpf,
                            CardNumber = model.CardNumber,
                            Hour = GetNomalizedHour(model.Hour),
                            StoreOwner = model.StoreOwner,
                            StoreName = model.StoreName,
                            FinancialTransactionType = financialTransactionType
                        });
                }

                _repository.FinancialTransactionRepository.AddRange(listFinancialTransaction);
                await _repository.CommitAsync();

                return new BaseCommandResult()
                {
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {

                throw;
            }
        }
        private double GetNomalizedValue(string modelValue)
        {
            return double.Parse(modelValue) / 100;
        }

        private TimeSpan GetNomalizedHour(string modelValue)
        {
            var hour = int.Parse(modelValue[..2]);
            var minutes = int.Parse(modelValue.Substring(2, 2));
            var secunds = int.Parse(modelValue.Substring(4, 2));
            return new TimeSpan(hour, minutes, secunds);
        }

        private DateTime GetNomalizedDate(string modelValue)
        {
            var year = int.Parse(modelValue[..4]);
            var mounth = int.Parse(modelValue.Substring(4, 2));
            var day = int.Parse(modelValue.Substring(6, 2));
            return new DateTime(year, mounth, day).ToUniversalTime();
        }
    }
}