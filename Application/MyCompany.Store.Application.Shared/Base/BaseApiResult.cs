using MyCompany.Store.Application.Shared.Enums;
using Newtonsoft.Json;

namespace MyCompany.Store.Application.Shared.Base
{
    public abstract class BaseApiResult
    {
        [JsonIgnore]
        public ResponseStatus ResultCode { get; set; }

        public BaseApiResult(ResponseStatus resultCode)
        {
            ResultCode = resultCode;
        }
    }
}
