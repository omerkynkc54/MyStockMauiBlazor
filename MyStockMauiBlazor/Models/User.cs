using SQLite;
using System.Transactions;

namespace MyStockMauiBlazor.Models
{
    public class User
    {
        public int UserId { get; set; } // Identity and Primary Key
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        // Navigation properties for related login logs and transactions
        public ICollection<LoginLog> LoginLogs { get; set; }
        public ICollection<System.Transactions.Transaction> Transactions { get; set; }
    }
}