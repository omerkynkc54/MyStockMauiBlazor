using SQLite;

namespace MyStockMauiBlazor.Models
{
    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int StockId { get; set; } // Primary Key
        public string StockCode { get; set; }
        public float? UnitPrice { get; set; }
        public DateTime? UpdateDate { get; set; }

        // Navigation property for related transactions
        public ICollection<Transaction> Transactions { get; set; }
    }
}
