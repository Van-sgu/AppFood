using SQLite;
using FoodStreet.Models;

namespace FoodStreet.Data
{
    public class DataServices
    {
        SQLiteAsyncConnection _db;

        private async Task<SQLiteAsyncConnection> GetDatabaseAsync()
        {
            if (_db != null) return _db;
            string dbPath;
#if WINDOWS
            dbPath = @"D:\AppFood\FoodStreet.db3";
            var directory = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
#else
            dbPath = Path.Combine(FileSystem.AppDataDirectory, "FoodStreet.db3");
#endif
            if (true) 
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("FoodStreet.db3");
                using var newStream = File.Create(dbPath);
                await stream.CopyToAsync(newStream);
            }

            _db = new SQLiteAsyncConnection(dbPath);
            await _db.CreateTableAsync<POI>();
            return _db;
        }

        public async Task<List<POI>> GetItemsAsync()
        {
            var db = await GetDatabaseAsync();
            return await _db.Table<POI>().ToListAsync();
        }

        public async Task<int> SaveItemAsync(POI item)
        {
            var db = await GetDatabaseAsync();
            return item.Id != 0 ? await db.UpdateAsync(item) : await db.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(POI item)
        {
            var db = await GetDatabaseAsync();
            return await _db.DeleteAsync(item);
        }
    }
}
