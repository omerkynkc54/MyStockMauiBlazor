using SQLite;

namespace MyStockMauiBlazor.Models
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // Identity and Primary Key
        public int UserId { get; set; } // Foreign Key
        public int StockId { get; set; } // Foreign Key
        public float Amount { get; set; }
        public float UnitPrice { get; set; }
        public DateTime TransactionDate { get; set; }

        // Navigation properties to User and Stock
        public User User { get; set; }
        public Stock Stock { get; set; }
    }
}
