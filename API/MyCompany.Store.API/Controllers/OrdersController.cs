using Mediator.Commands;
using Mediator.Queries;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Store.API.Controllers.Base;
using MyCompany.Store.Application.Orders.Commands.CreateOrder;
using MyCompany.Store.Application.Orders.Commands.EditOrder;
using MyCompany.Store.Application.Orders.Commands.RemoveOrder;
using MyCompany.Store.Application.Orders.Queries.GetAllOrders;
using MyCompany.Store.Application.Orders.Queries.GetAllOrders.Dtos;
using MyCompany.Store.Application.Orders.Queries.GetOrderDetails;
using MyCompany.Store.Application.Orders.Queries.GetOrderDetails.Dtos;
using MyCompany.Store.Application.Shared.Commands;
using MyCompany.Store.Application.Shared.Queries;
using MyCompany.Store.Core.Domain.Orders.Enums;
using System.Net;

namespace MyCompany.Store.API.Controllers
{
    public class OrdersController : BaseController
    {
        public OrdersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }


        [HttpPost]
        [ProducesResponseType(typeof(CommandResult), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return HandleServiceResult(await _commandDispatcher.Dispatch<CreateOrderCommand, CommandResult>(command, CancellationToken.None));
        }

        [HttpPut("{orderId}")]
        [ProducesResponseType(typeof(CommandResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditOrder(long orderId, [FromBody] EditOrderCommand command)
        {
            return HandleServiceResult(await _commandDispatcher.Dispatch<EditOrderCommand, CommandResult>(new EditOrderCommand(orderId, command.ClientName, command.AdditionalInfo, command.Status), CancellationToken.None));
        }

        [HttpDelete("{orderId}")]
        [ProducesResponseType(typeof(CommandResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveOrder(long orderId)
        {
            return HandleServiceResult(await _commandDispatcher.Dispatch<RemoveOrderCommand, CommandResult>(new RemoveOrderCommand(orderId), CancellationToken.None));
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(QueryResult<GetOrderDetailsDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderDetails(long orderId)
        {
            return HandleServiceResult(await _queryDispatcher.Dispatch<GetOrderDetailsQuery, QueryResult<GetOrderDetailsDto>>(new GetOrderDetailsQuery(orderId), CancellationToken.None));
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueryResult<IEnumerable<GetAllOrdersDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrders(int page, int perPage, DateOnly? createdDate, OrderStatus? status)
        {
            return HandleServiceResult(await _queryDispatcher.Dispatch<GetAllOrdersQuery, QueryResult<IEnumerable<GetAllOrdersDto>>>(new GetAllOrdersQuery(page, perPage, createdDate, status), CancellationToken.None));
        }
    }
}