using System;
using FluentAssertions;
using Customer.Framework.Shared.Exception;
using Customer.Framework.Shared.Util;
using Xunit;

namespace Customer.Framework.UnitTests.Utils
{
    public class EnsureUtilityTests
    {
        [Fact]
        public void EnsureThat_WhenConditionIsFalse_ThrowsException()
        { 
            Action action = () => EnsureUtility.EnsureThat<BadRequestException>(false, "Bad Request");
            action.Should().Throw<BadRequestException>().WithMessage("Bad Request");
        }
    }  
}

