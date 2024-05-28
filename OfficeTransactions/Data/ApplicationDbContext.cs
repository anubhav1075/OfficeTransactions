using Microsoft.EntityFrameworkCore;
using OfficeTransactions.Models;

namespace OfficeTransactions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Transactions> Transactions { get; set; }
    }
}
