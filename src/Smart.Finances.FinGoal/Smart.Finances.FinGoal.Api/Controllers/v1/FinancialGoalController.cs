using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Add;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Update;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.UpdateStatus.Commands;

namespace Smart.Finances.FinGoal.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/financial-goal")]
    public class FinancialGoalController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddFinancialGoalCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateFinancialGoalCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("cancell/{id}")]
        public async Task<IActionResult> CancellAsync(Guid id)
        {
            return Ok(await _mediator.Send(new CancellFinancialGoalCommand(id)));
        }

        [HttpPut("back/{id}")]
        public async Task<IActionResult> BackAsync(Guid id)
        {
            return Ok(await _mediator.Send(new BackFinancialGoalCommand(id)));
        }

        [HttpPut("Hold/{id}")]
        public async Task<IActionResult> HoldAsync(Guid id)
        {
            return Ok(await _mediator.Send(new HoldFinancialGoalCommand(id)));
        }
    }
}
