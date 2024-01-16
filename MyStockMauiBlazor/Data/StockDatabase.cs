using SQLite;
using MyStockMauiBlazor.Models;
using System.Diagnostics;

namespace MyStockMauiBlazor.Data
{
    public class StockDatabase
    {
        SQLiteAsyncConnection Database;
        public StockDatabase()
        {
        }

        async Task Init()
        {
            if (Database != null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<User>();
            await Database.CreateTableAsync<Stock>(); 
            await Database.CreateTableAsync<Transaction>(); 
            await Database.CreateTableAsync<LoginLog>();
        }

        public async Task<bool> AuthenticateUserAsync(string username, string hashedPassword)
        {
            await Init();
            var user = await Database.Table<User>()
                                     .Where(u => u.UserName == username && u.UserPassword == hashedPassword)
                                     .FirstOrDefaultAsync();
            return user != null;
        }

        public async Task CreateTestUserIfNotExistsAsync()
        {
            await Init();
            string testUsername = "1";
            string testPassword = "1"; // This should be hashed in a real application

            Debug.WriteLine("Created admin user 1 1: please delete that in the prod");

            var existingUser = await Database.Table<User>()
                                             .Where(u => u.UserName == testUsername)
                                             .FirstOrDefaultAsync();

            if (existingUser == null)
            {
                var testUser = new User { UserName = testUsername, UserPassword = testPassword };
                await Database.InsertAsync(testUser);
            }
        }
    }
}
