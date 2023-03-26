namespace MyCompany.Store.SPA.Models
{
    public record QueryResult<T>
    {
        public T Payload { get; init; }
        public int Count { get; init; }
        public string? Error { get; init; }
    }
}
