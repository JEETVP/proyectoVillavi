using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villavi.Shared.Entities;

namespace Villavi.Api.Controllers
{
    [ApiController]
    [Route("/api/suppliers")]
    public class SuppliersController : ControllerBase
    {
        private readonly DataContext dataContext;

        public SuppliersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Suppliers.ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var supplier = await
                dataContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Supplier suppliers)
        {
            dataContext.Suppliers.Add(suppliers);
            await dataContext.SaveChangesAsync();
            return Ok(suppliers);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Supplier suppliers)
        {
            dataContext.Suppliers.Update(suppliers);
            await dataContext.SaveChangesAsync();
            return Ok(suppliers);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Suppliers.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
