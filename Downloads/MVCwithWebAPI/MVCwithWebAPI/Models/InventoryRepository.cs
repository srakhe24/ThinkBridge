using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCwithWebAPI.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly SqlDbContext db = new SqlDbContext();
        public async Task Add(Inventory inventory)
        {
            inventory.Id = Guid.NewGuid().ToString();
            db.Inventories.Add(inventory);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Inventory> GetEmployee(string id)
        {
            try
            {
                Inventory inventory = await db.Inventories.FindAsync(id);
                if (inventory == null)
                {
                    return null;
                }
                return inventory;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            try
            {
                var inventory = await db.Inventories.ToListAsync();
                return inventory.AsQueryable();
            }
            catch
            {
                throw;

            }
        }
        public async Task Update(Inventory inventory)
        {
            try
            {
                db.Entry(inventory).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id)
        {
            try
            {
                Inventory inventory = await db.Inventories.FindAsync(id);
                db.Inventories.Remove(inventory);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        private bool EmployeeExists(string id)
        {
            return db.Inventories.Count(e => e.Id == id) > 0;
        }

    }
}