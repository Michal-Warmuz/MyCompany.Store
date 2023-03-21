using MyCompany.Store.Infrastructure.Web.Essentials.Enums;
using Newtonsoft.Json;

namespace MyCompany.Store.Infrastructure.Web.Essentials.Base
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
