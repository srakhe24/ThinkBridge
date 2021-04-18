using MVCwithWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVCwithWebAPI.Controllers
{
    public class InventoriesApiController : ApiController
    {
        private readonly IInventoryRepository _iInventoryRepository = new InventoryRepository();

        [HttpGet]
        [Route("api/Inventory/Get")]
        public async Task<IEnumerable<Inventory>> Get()
        {
            return await _iInventoryRepository.GetInventories();
        }

        [HttpPost]
        [Route("api/Inventory/Create")]
        public async Task CreateAsync([FromBody]Inventory employee)
        {
            if (ModelState.IsValid)
            {
                await _iInventoryRepository.Add(employee);
            }
        }

        [HttpGet]
        [Route("api/Inventory/Details/{id}")]
        public async Task<Inventory> Details(string id)
        {
            var result = await _iInventoryRepository.GetEmployee(id);
            return result;
        }

        [HttpPut]
        [Route("api/Inventory/Edit")]
        public async Task EditAsync([FromBody]Inventory employee)
        {
            if (ModelState.IsValid)
            {
                await _iInventoryRepository.Update(employee);
            }
        }

        [HttpDelete]
        [Route("api/Inventory/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await _iInventoryRepository.Delete(id);
        }
    }
}