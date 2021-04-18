
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCwithWebAPI.Models
{
    public interface IInventoryRepository
    {
        Task Add(Inventory inventory);
        Task Update(Inventory inventory);
        Task Delete(string id);
        Task<Inventory> GetEmployee(string id);
        Task<IEnumerable<Inventory>> GetInventories();
    }
}
