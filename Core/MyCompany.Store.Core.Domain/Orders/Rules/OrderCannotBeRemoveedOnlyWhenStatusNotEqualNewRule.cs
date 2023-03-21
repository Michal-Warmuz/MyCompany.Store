using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders.Rules
{
    internal class OrderCannotBeRemoveedOnlyWhenStatusNotEqualNewRule : IBusinessRule
    {
        private readonly OrderStatus _status;

        internal OrderCannotBeRemoveedOnlyWhenStatusNotEqualNewRule(OrderStatus status)
        {
            _status = status;
        }

        public string Message => $"Można usuwać zamówienia tylko ze statusem {OrderStatus.New}";

        public bool IsBroken() => _status != OrderStatus.New;
    }
}
