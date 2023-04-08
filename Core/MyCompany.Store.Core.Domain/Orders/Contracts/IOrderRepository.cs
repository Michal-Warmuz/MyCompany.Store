﻿namespace MyCompany.Store.Core.Domain.Orders.Contracts
{
    public interface IOrderRepository : IAsyncRepository<Order, OrderId>
    {
        void Update(Order order);
    }
}
