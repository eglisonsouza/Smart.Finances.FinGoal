using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.FinGoal.Application.Commands.TransactionCommands.Events.OperationTransaction;

namespace Smart.Finances.FinGoal.Api.Controllers.v1
{
    [Route("api/v1/operation-transaction")]
    public class OperationTransactionController(IMediator mediator) : BaseController(mediator)
    {
        [HttpPost("deposit")]
        public async Task<IActionResult> DepositAsync(DepositTransactionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> WithdrawAsync(WithdrawTransactionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
