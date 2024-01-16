using SQLite;
using MyStockMauiBlazor.Models;

namespace MyStockMauiBlazor.Services
{
    public class DatabaseService
    {
        SQLiteAsyncConnection Database;
        public DatabaseService()
        {
        }

        async Task Init()
        {
            if (Database != null)
                return;

            // Assuming Constants.DatabasePath and Constants.Flags are defined
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<User>();
        }

    }
}
