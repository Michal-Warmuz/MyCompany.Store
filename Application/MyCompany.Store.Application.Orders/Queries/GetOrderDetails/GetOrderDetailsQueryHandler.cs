using Dapper;
using Mediator.Queries;
using MyCompany.Store.Application.Orders.Queries.GetAllOrders.Dtos;
using MyCompany.Store.Application.Orders.Queries.GetOrderDetails.Dtos;
using MyCompany.Store.Application.Shared.Data;
using MyCompany.Store.Application.Shared.Enums;
using MyCompany.Store.Application.Shared.Queries;

namespace MyCompany.Store.Application.Orders.Queries.GetOrderDetails
{
    internal class GetOrderDetailsQueryHandler : IQueryHandler<GetOrderDetailsQuery, QueryResult<GetOrderDetailsDto>>
    {

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetOrderDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<QueryResult<GetOrderDetailsDto>> Handle(GetOrderDetailsQuery query, CancellationToken cancellation)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            string orderSQL = @$"
                  SELECT 
	                   [Order].[Id]
                      ,[Order].[{nameof(GetOrderDetailsDto.CreateDate)}]
                      ,[Order].[{nameof(GetOrderDetailsDto.ClientName)}]
                      ,[Order].[{nameof(GetOrderDetailsDto.AdditionalInfo)}]
                      ,[Order].[{nameof(GetOrderDetailsDto.Status)}]
                      ,SUM([OrderLine].[Price]) AS [{nameof(GetAllOrdersDto.TotalPrice)}]
                      ,[Orderline].[{nameof(GetOrderLineDetailsDto.Product)}]
                      ,[Orderline].[{nameof(GetOrderLineDetailsDto.Price)}]
                      ,[Orderline].[OrderId] AS [OrderId]
                  FROM [dbo].[Orders] AS [Order]
				  INNER JOIN [dbo].[OrderLines] as [Orderline] 
                  ON  [Order].[Id] = [Orderline].[OrderId]
				  WHERE  [Order].[Id]  = @OrderId
				  GROUP BY
	                   [Order].[Id]
                      ,[Order].[{nameof(GetOrderDetailsDto.CreateDate)}]
                      ,[Order].[{nameof(GetOrderDetailsDto.ClientName)}]
                      ,[Order].[{nameof(GetOrderDetailsDto.AdditionalInfo)}]
                      ,[Order].[{nameof(GetOrderDetailsDto.Status)}]
                      ,[Orderline].[{nameof(GetOrderLineDetailsDto.Product)}]
                      ,[Orderline].[{nameof(GetOrderLineDetailsDto.Price)}]
                      ,[Orderline].[OrderId]
                ";

            var result = await connection.QueryAsync<GetOrderDetailsDto, List<GetOrderLineDetailsDto>, GetOrderDetailsDto>           (orderSQL, 
                         (order, orderLines) =>
                            {
                                return new GetOrderDetailsDto(order, orderLines);
                            }, 
                         new { query.OrderId }, 
                         splitOn: "OrderId");


            var order = result.FirstOrDefault();

            return new QueryResult<GetOrderDetailsDto>(ResponseStatus.Ok, payload: order);
        }
    }
}
