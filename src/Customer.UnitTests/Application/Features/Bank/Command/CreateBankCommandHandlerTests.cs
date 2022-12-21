using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Customer.Application.Features.Bank.Command;
using Customer.Application.Features.Bank.Response;
using Customer.Domain.Repository;
using Customer.Tests.Common.TestData;
using Xunit;
using Core = Customer.Domain.Core;

namespace Customer.UnitTests.Application.Features.Bank.Command
{
    public class CreateBankCommandHandlerTests
    {
        private readonly Mock<IBankRepository> _repository;
        private readonly CreateBankCommandHandler _handler;

        public CreateBankCommandHandlerTests()
        {
            _repository = new Mock<IBankRepository>();
            _handler = new CreateBankCommandHandler(_repository.Object);
        }

        [Fact]
        public async Task ShouldCreateBank()
        {
            var command = BankData.BankCommandFaker.Generate();
            _repository.Setup(x => x.Create(It.Is<Core.Bank>(x => x.IfscCode == command.IfscCode && x.Name == command.Name)))
                .ReturnsAsync(1);

            var results = await _handler.Handle(command, default);

            results.Should().BeEquivalentTo(new BankCreatedResponse { BankId = 1 });
        }
    }
}