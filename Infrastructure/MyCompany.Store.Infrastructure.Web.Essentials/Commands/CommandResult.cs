using MyCompany.Store.Infrastructure.Web.Essentials.Base;
using MyCompany.Store.Infrastructure.Web.Essentials.Enums;

namespace MyCompany.Store.Infrastructure.Web.Essentials.Commands
{
    public class CommandResult : BaseApiResult
    {
        public string? Error { get; set; }

        public CommandResult(ResponseStatus status, string? error = null) : base(status)
        {
            Error = error;
        }
    }

    public class CommandResult<T> : CommandResult
    {
        public T Payload { get; set; }

        public CommandResult(ResponseStatus status, T payload, string? error = null) : base(status, error)
        {
            Payload = payload;
        }
    }
}
