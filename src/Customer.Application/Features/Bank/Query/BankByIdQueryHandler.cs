using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Customer.Application.Features.Bank.Response;
using Customer.Framework.Shared.Exception;
using Customer.Framework.Shared.Extension;
using Customer.Persistence.Provider.Contract;

namespace Customer.Application.Features.Bank.Query
{
    public class BankByIdQueryHandler : IRequestHandler<BankByIdQuery, BankResponse>
    {
        private readonly IBankProvider _bankProvider;
        private readonly IMapper _mapper;

        public BankByIdQueryHandler(IBankProvider bankProvider, IMapper mapper)
        {
            _bankProvider = bankProvider;
            _mapper = mapper;
        }

        public async Task<BankResponse> Handle(BankByIdQuery query, CancellationToken cancellationToken)
        {
            var bank = await _bankProvider.Bank(query.BankId);
            bank.EnsureNotNull<NotFoundException>($"Bank with {query.BankId} not exist.");
            return _mapper.Map<BankResponse>(bank);
        }
    }
}