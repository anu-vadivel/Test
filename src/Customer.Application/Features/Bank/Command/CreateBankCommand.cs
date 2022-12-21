using MediatR;
using Customer.Application.Features.Bank.Response;

namespace Customer.Application.Features.Bank.Command
{
    public class CreateBankCommand : IRequest<BankCreatedResponse>
    {
        public string IfscCode { get; set; }
        public string Name { get; set; }
    }
}