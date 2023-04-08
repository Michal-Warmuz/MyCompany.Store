using Dapper;
using Mediator.Queries;
using MyCompany.Store.Application.Orders.Queries.GetAllOrders.Dtos;
using MyCompany.Store.Application.Shared.Data;
using MyCompany.Store.Application.Shared.Enums;
using MyCompany.Store.Application.Shared.Queries;
using MyCompany.Store.Core.Domain.Orders;

namespace MyCompany.Store.Application.Orders.Queries.GetAllOrders
{
    internal class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, QueryResult<IEnumerable<GetAllOrdersDto>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllOrdersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<QueryResult<IEnumerable<GetAllOrdersDto>>> Handle(GetAllOrdersQuery query, CancellationToken cancellation)
        {

            var connection = _sqlConnectionFactory.GetOpenConnection();

            var status = OrderStatus.GetOrderStatus(query.Status)?.Value;
            var createdDate = query.CreatedDate.HasValue ? query.CreatedDate.Value.ToShortDateString() : null;

            string ordersSQL = @$"
                  SELECT 
	                    [Order].[Id] AS [{nameof(GetAllOrdersDto.OrderId)}]
                        ,[Order].[{nameof(GetAllOrdersDto.CreateDate)}]
                        ,[Order].[{nameof(GetAllOrdersDto.ClientName)}]
                        ,[Order].[{nameof(GetAllOrdersDto.AdditionalInfo)}]
                        ,[Order].[{nameof(GetAllOrdersDto.Status)}]
	                    ,SUM([OrderLine].[Price]) AS [{nameof(GetAllOrdersDto.TotalPrice)}]
                  FROM [dbo].[Orders] AS [Order]
                  LEFT JOIN [dbo].OrderLines AS [OrderLine] 
                  ON [ORDER].[Id] = [OrderLine].OrderId
                  WHERE 
                        ((@status IS NULL) OR (@status IS NOT NULL AND [Order].[Status] = @status))
                        AND ((@createdDate IS NULL) OR (@createdDate IS NOT NULL AND CONVERT(VARCHAR(25), [Order].[CreateDate], 126) LIKE @createdDate))
                  GROUP BY 
                        [Order].[Id]
                        ,[Order].[CreateDate]
                        ,[Order].[ClientName]
                        ,[Order].[AdditionalInfo]
                        ,[Order].[Status]
                  ORDER BY [Order].[Id]
                  OFFSET (@Page - 1) * @PerPage ROWS 
                  FETCH NEXT @PerPage ROWS ONLY";

            var orders = await connection.QueryAsync<GetAllOrdersDto>(ordersSQL, new { query.PerPage, query.Page, status, createdDate   });

            const string recordsCountSql = "SELECT COUNT(*) FROM [dbo].[Orders]";

            var recordsCount = await connection.ExecuteScalarAsync<int>(recordsCountSql);

            return new QueryResult<IEnumerable<GetAllOrdersDto>> (ResponseStatus.Ok, orders, count: recordsCount);
        }
    }
}
