using Mediator.Commands;
using Mediator.Queries;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Store.Application.Shared.Base;
using MyCompany.Store.Application.Shared.Enums;

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

        protected IActionResult HandleServiceResult(BaseApiResult serviceResponse) => serviceResponse.ResultCode switch
        {
            ResponseStatus.Ok => Ok(serviceResponse),
            ResponseStatus.ValidationErrors => BadRequest(serviceResponse),
            ResponseStatus.Unauthorized => Unauthorized(serviceResponse),
            ResponseStatus.Forbidden => StatusCode(StatusCodes.Status403Forbidden),
            ResponseStatus.Conflict => Conflict(serviceResponse),
            ResponseStatus.NotFound => NotFound(serviceResponse),
            ResponseStatus.Unknown => BadRequest(serviceResponse),
            ResponseStatus.Created => StatusCode(StatusCodes.Status201Created)
        };
    }
}
