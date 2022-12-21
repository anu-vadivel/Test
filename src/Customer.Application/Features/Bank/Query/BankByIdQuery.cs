using MediatR;
using Customer.Application.Features.Bank.Response;

namespace Customer.Application.Features.Bank.Query
{
    public class BankByIdQuery : IRequest<BankResponse>
    {
        public int BankId { get; set; }
    }
}