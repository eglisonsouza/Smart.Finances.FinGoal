using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Smart.Finances.FinGoal.Api.Controllers
{
    [ApiController]
    public class BaseController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator _mediator = mediator;
    }
}
