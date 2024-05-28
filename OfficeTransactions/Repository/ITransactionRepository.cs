using OfficeTransactions.Models;
using System.Transactions;

namespace OfficeTransactions.Repository
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<Transactions>> GetAllTransactions();
        public Task<Transactions> GetTransactionById(int id);
        public Task<Transactions> AddTransaction(Transactions transactions);

    }
}
