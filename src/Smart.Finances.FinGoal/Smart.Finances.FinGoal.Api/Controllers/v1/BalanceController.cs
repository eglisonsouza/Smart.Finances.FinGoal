using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smart.Finances.FinGoal.Application.Queries.BalanceQueries;

namespace Smart.Finances.FinGoal.Api.Controllers.v1
{
    [Route("api/v1/balance")]
    public class BalanceController(IMediator mediator) : BaseController(mediator)
    {
        [HttpGet]
        public IActionResult GetAsync([FromQuery] Guid query)
        {

            return Ok(_mediator.Send(new GetByFinancialGoalQuery { FinancialGoalId = query }));
        }
    }
}
