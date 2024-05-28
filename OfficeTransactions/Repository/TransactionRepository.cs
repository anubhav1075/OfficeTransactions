using Microsoft.EntityFrameworkCore;
using OfficeTransactions.Data;
using OfficeTransactions.Models;

namespace OfficeTransactions.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context= context;
        }

        public async Task<Transactions> AddTransaction(Transactions transactions)
        {
            var lastTransaction = await _context.Transactions.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            float balance = 0;
            if(transactions.Credit && lastTransaction!=null)
            {
                balance = lastTransaction.Balance + transactions.Amount;
                transactions.Balance = balance;
            }
            else if(transactions.Debit && lastTransaction != null)
            {
                balance = lastTransaction.Balance - transactions.Amount;
                transactions.Balance = balance;
            }
            else if(lastTransaction==null)
                transactions.Balance = transactions.Amount;

            _context.Transactions.Add(transactions);
            await _context.SaveChangesAsync();
            return transactions;
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactions()
        {
            return await _context.Transactions.OrderByDescending(s => s.Id).ToListAsync();
        }

        public async Task<Transactions> GetTransactionById(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }
    }
}
