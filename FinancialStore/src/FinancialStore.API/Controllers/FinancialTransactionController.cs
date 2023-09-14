using FinancialStore.Contracts.DTO;
using FinancialStore.Core.Exceptions;
using FinancialStore.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinancialStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinancialTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FinancialTransactionSummaryDTO>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseCommandResult))]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllFinancialTransactionQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseCommandResult))]
        public async Task<IActionResult> Post([FromBody] List<FinancialTransactionDTO> models)
        {
            try
            {
                var response = await _mediator.Send(new CreateFinancialTransactionCommand(models), CancellationToken.None);
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseCommandResult
                {
                    IsSuccess = false,
                    Errors = ex.Errors.ToArray(),
                });
            }
        }
    }
}
