using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders
{
    public class OrderStatus : ValueObject
    {
        private OrderStatus() { }

        private OrderStatus(string value)
        {
            Value = value;
        }

        public static OrderStatus New => new OrderStatus(nameof(New));
        public static OrderStatus Confirm => new OrderStatus(nameof(Confirm));
        public static OrderStatus Delivery => new OrderStatus(nameof(Delivery));
        public static OrderStatus Cancel => new OrderStatus(nameof(Cancel));

        public string Value { get; }

        internal static OrderStatus Create(string value)
        {
            return new OrderStatus(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
