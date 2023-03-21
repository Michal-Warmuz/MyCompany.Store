using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders.Rules
{
    internal class OrderCannotBeEditedWhenStatusIsNewRule : IBusinessRule
    {
        private readonly OrderStatus _status;

        internal OrderCannotBeEditedWhenStatusIsNewRule(OrderStatus status)
        {
            _status = status;
        }

        public string Message => $"Nie możemy edytować zamówienia gdy status zamówienia to {OrderStatus.New}";

        public bool IsBroken() => _status == OrderStatus.New;
    }
}
