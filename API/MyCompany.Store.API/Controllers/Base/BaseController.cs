using Mediator.Commands;
using Mediator.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MyCompany.Store.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IQueryDispatcher _queryDispatcher;
        protected readonly ICommandDispatcher _commandDispatcher;

        public BaseController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }
    }
}
