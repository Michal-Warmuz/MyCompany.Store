using MyCompany.Store.Application.Shared.Base;
using MyCompany.Store.Application.Shared.Enums;

namespace MyCompany.Store.Application.Shared.Queries
{
    public class QueryResult<T> : BaseApiResult
    {
        public T? Payload { get; set; }
        public string? Error { get; set; }
        public int Count { get; set; }


        public QueryResult(ResponseStatus resultCode, T? payload = default(T), string? error = null, int count = 0) : base(resultCode)
        {
            ResultCode = resultCode;
            Payload = payload;
            Error = error;
            Count = count;
        }
    }
}
