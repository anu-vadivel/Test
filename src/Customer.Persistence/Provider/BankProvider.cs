using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Customer.Persistence.DAO;
using Customer.Persistence.Provider.Contract;

namespace Customer.Persistence.Provider
{
    /// <summary>
    /// Provider returns DAO and will be mainly used by queries handlers (read operations)
    /// These classes will wrap abstraction over DB context
    /// </summary>
    public class BankProvider : IBankProvider
    {
        private readonly CustomerDbContext _dbContext;

        public BankProvider(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Bank> Bank(int bankId) =>
            await _dbContext.Banks.FirstOrDefaultAsync(x => x.Id == bankId);

        public async Task<Bank> Bank(string code) =>
            await _dbContext.Banks.FirstOrDefaultAsync(x => x.IfscCode == code);

        public async Task<List<Bank>> Banks() =>
            await _dbContext.Banks.ToListAsync();
    }
}