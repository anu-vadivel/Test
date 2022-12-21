using FluentAssertions;
using Customer.Api.Attribute;
using Customer.Application.Features.Bank.Response;
using Xunit;

namespace Customer.UnitTests.Api.Attribute
{
    public class ApiSuccessResponseAttributeTests
    {
        [Fact]
        public void ShouldSetStatusdDescriptionAndResponseType()
        {
            var attr = new ApiSuccessResponseAttribute(201, "something created", typeof(BankCreatedResponse));
            
            attr.StatusCode.Should().Be(201);
            attr.Description.Should().Be("something created");
            attr.Type.Name.Should().Be(nameof(BankCreatedResponse));
        }
    }
}