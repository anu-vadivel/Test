using System.Diagnostics.CodeAnalysis;

namespace Customer.Framework.Shared.Exception
{
    [ExcludeFromCodeCoverage]
    public class ForbiddenException : System.Exception
    {
        public ForbiddenException(string message, System.Exception ex = null) : base(message, ex)
        {
        }
    }
}