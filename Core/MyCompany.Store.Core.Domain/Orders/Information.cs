using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders
{
    public class Information : ValueObject
    {
        public string Value { get; }

        private Information() { }

        private Information(string value)
        {
            Value = value;
        }

        public static Information CreateNew(string value)
        {
            return new Information(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
