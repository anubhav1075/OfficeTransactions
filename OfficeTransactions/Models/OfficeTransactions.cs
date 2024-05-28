using System.ComponentModel.DataAnnotations;

namespace OfficeTransactions.Models
{
    public class OfficeTransactions
    {
        [Key]
        public int Id { get; set; }

        public DateTime TransactionDate { get; set; }
        [Required]
        public string Description { get; set; }

        public bool Credit { get; set; }

        public bool Debit { get; set; }

        public float Balance { get; set; }
        [Required]
        public float Amount { get; set; }

    }

}
