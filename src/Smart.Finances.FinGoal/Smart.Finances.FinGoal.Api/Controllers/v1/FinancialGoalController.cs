using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.FinGoal.Application.Commands.FinancialGoalCommands.Add;

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
    }
}
