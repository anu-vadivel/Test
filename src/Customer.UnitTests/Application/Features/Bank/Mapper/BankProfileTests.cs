using AutoMapper;
using FluentAssertions;
using Customer.Application.Features.Bank.Mapper;
using Customer.Application.Features.Bank.Response;
using Xunit;

namespace Customer.UnitTests.Application.Features.Bank.Mapper
{
    public class BankProfileTests
    {
        private readonly IMapper _mapper;

        public BankProfileTests()
        {
            _mapper = InitializeAutoMapper();
        }

        [Fact]
        public void ShouldMapBankDaoToDto()
        {
            var dao = new Customer.Persistence.DAO.Bank { Id = 1, Name = "icici", IfscCode = "icici123" };
            var response = _mapper.Map<BankResponse>(dao);
            response.Should().BeEquivalentTo(dao);
        }

        private static IMapper InitializeAutoMapper()
        {
            return new MapperConfiguration(mc => { mc.AddProfile(new BankMapper()); }).CreateMapper();
        }
    }
}