using AppSQlite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSQlite.Interfaces
{
    public interface ISqliteService
    {
        Task<List<Item>> GetItemsAsync();

        Task<Item> GetItemAsync(int id);

        Task<int> SaveItemAsync(Item item);

        Task<int> DeleteItemAsync(Item item);
    }
}