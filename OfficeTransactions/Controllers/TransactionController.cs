using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeTransactions.Models;
using OfficeTransactions.Repository;

namespace OfficeTransactions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository= transactionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transactions>>> GetAllTransactions()
        {
            var entry = await _transactionRepository.GetAllTransactions();
            if(entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transactions>> GetTransactionById(int id)
        {
            var entry = await _transactionRepository.GetTransactionById(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost]
        public async Task<ActionResult<Transactions>> AddTransaction(Transactions transactions)
        {
            var entry = await _transactionRepository.AddTransaction(transactions);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }
    }
}
