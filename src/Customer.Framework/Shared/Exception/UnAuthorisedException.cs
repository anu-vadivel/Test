using System.Diagnostics.CodeAnalysis;

namespace Customer.Framework.Shared.Exception
{
    [ExcludeFromCodeCoverage]
    public class UnAuthorisedException : System.Exception
    {
        public UnAuthorisedException(string message, System.Exception ex = null) : base(message, ex)
        {
        }
    }
}