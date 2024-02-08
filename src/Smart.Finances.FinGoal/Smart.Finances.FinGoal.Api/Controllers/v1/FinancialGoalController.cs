using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Add;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Update;

namespace Smart.Finances.FinGoal.Api.Controllers.v1
{
    [ApiController]
    [Route("financial-goal")]
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
    }
}
