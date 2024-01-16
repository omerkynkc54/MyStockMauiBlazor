using SQLite;
using MyStockMauiBlazor.Models;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyStockMauiBlazor.Data
{
    public class StockDatabase
    {
        SQLiteAsyncConnection Database;

        private async Task Init()
        {
            if (connection != null)
                return;

            try
            {
                connection = new SQLiteAsyncConnection(dbPath);

                connection.Tracer = new Action<string>(q => Debug.WriteLine(q));
                connection.Trace = true;

                await CreateTables();
                var count = await CountItems();

                if (count == 0)
                {
                    await AddInitialData();
                    await CheckData();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task<List<Transaction>> GetAllTransaction()
        {
            await Init();
            return await Database.Table<Transaction>().ToListAsync();
        }

        public async Task<bool> AuthenticateUserAsync(string username, string hashedPassword)
        {
            await Init();
            var user = await Database.Table<User>()
                                     .Where(u => u.Name == username && u.Password == hashedPassword)
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
                                             .Where(u => u.Name == testUsername)
                                             .FirstOrDefaultAsync();

            if (existingUser == null)
            {
                var testUser = new User { Name = testUsername, Password = testPassword };
                await Database.InsertAsync(testUser);
            }
        }
    }
}
