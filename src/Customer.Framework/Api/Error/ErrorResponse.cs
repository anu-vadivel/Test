using Newtonsoft.Json;
using Customer.Framework.Shared.Util;

namespace Customer.Framework.Api.Error
{
    /// <summary>
    /// A defined error response structure from the API  
    /// </summary>
    public class ErrorResponse
    {
        public ErrorDescription Error { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}