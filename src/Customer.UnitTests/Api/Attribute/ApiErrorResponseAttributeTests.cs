using FluentAssertions;
using Customer.Api.Attribute;
using Customer.Framework.Api.Error;
using Xunit;

namespace Customer.UnitTests.Api.Attribute
{
    public class ApiErrorResponseAttributeTests
    {
        [Fact]
        public void ShouldSetStatusdDescriptionAndErrorResponseType()
        {
            var attr = new ApiErrorResponseAttribute(400, "something bad");
            
            attr.StatusCode.Should().Be(400);
            attr.Description.Should().Be("something bad");
            attr.Type.Name.Should().Be(nameof(ErrorResponse));
        }
    }
    
    
}