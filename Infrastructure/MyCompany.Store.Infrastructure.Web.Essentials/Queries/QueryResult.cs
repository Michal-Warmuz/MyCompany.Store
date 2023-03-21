using MyCompany.Store.Infrastructure.Web.Essentials.Base;
using MyCompany.Store.Infrastructure.Web.Essentials.Enums;

namespace MyCompany.Store.Infrastructure.Web.Essentials.Queries
{
    public class QueryResult<T> : BaseApiResult
    {
        public T Payload { get; set; }
        public string? Error { get; set; }


        public QueryResult(ResponseStatus resultCode, T payload, string? error = null) : base(resultCode)
        {
            ResultCode = resultCode;
            Payload = payload;
            Error = error;
        }

        public QueryResult(ResponseStatus resultCode, string? error = null) : base(resultCode)
        {
            ResultCode = resultCode;
            Error = error;
        }
    }
}
