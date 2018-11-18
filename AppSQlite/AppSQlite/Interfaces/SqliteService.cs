using AppSQlite.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppSQlite.Interfaces
{
    public class SqliteService : ISqliteService
    {
        private SQLiteAsyncConnection _sqlCon;

        public SqliteService()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            _sqlCon = new SQLiteAsyncConnection(databasePath);

            CreateDatabaseAsync();
        }

        private void CreateDatabaseAsync()
        {
            _sqlCon.CreateTableAsync<Item>().Wait();
        }

        #region Métodos CRUD

        public Task<List<Item>> GetItemsAsync()
        {
            return _sqlCon.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemAsync(int id)
        {
            return _sqlCon.Table<Item>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.Id != 0)
            {
                return _sqlCon.UpdateAsync(item);
            }
            else
            {
                return _sqlCon.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return _sqlCon.DeleteAsync(item);
        }

        #endregion Métodos CRUD
    }
}