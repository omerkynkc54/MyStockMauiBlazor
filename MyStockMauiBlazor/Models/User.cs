using SQLite;

namespace MyStockMauiBlazor.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // Identity and Primary Key
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<LoginLog> LoginLogs { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}