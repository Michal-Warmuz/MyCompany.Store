using MyCompany.Store.Core.Domain.SeedWork;

namespace MyCompany.Store.Core.Domain.Orders
{
    public class Client : ValueObject
    {
        public string Name { get; }

        private Client() { }

        private Client(string name)
        {
            Name = name;
        }

        public static Client CreateNew(string name)
        {
            return new Client(name);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
