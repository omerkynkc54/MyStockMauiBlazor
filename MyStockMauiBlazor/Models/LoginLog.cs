using SQLite;

namespace MyStockMauiBlazor.Models
{
    public class LoginLog
    {
        public int UserId { get; set; } // Foreign Key
        public DateTime LoginDateTime { get; set; } = DateTime.Now;

        // Navigation property to User
        public User User { get; set; }
    }
}
