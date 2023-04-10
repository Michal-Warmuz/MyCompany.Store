namespace MyCompany.Store.Application.Shared.Queries
{
    public record QueryResult<T>
    {
        public T? Payload { get; init; }
        public int Count { get; init; }


        public QueryResult(T? payload = default(T), int count = 0)
        {
            Payload = payload;
            Count = count;
        }
    }
}
