using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Persistence.DAO;

namespace Customer.Persistence.Provider.Contract
{
    public interface IBankProvider
    {
        Task<Bank> Bank(int bankId);
        Task<Bank> Bank(string code);
        Task<List<Bank>> Banks();
    }
}