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

            var dbPath = Path.Combine(FileSystem.Current.AppDataDirectory, "FoodStreet.db3");
            if (!File.Exists(dbPath))
            {
                try
                {
                    using var stream = await FileSystem.OpenAppPackageFileAsync("FoodStreet.db3");
                    using var newStream = File.Create(dbPath);
                    await stream.CopyToAsync(newStream);
                }
                catch (Exception ex)
                {
                    // Debug lỗi nếu bạn quên chưa để Build Action là MauiAsset
                    System.Diagnostics.Debug.WriteLine($"Lỗi copy database: {ex.Message}");
                }
            }

            _db = new SQLiteAsyncConnection(dbPath);
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
