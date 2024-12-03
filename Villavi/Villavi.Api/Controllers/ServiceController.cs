using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villavi.Shared.Entities;

namespace Villavi.Api.Controllers
{
    [ApiController]
    [Route("/api/services")]
    public class ServiceController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ServiceController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Services.Include(c => c.Car).ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var service = await
                dataContext.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Service service)
        {
            dataContext.Services.Add(service);
            await dataContext.SaveChangesAsync();
            return Ok(service);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Service service)
        {
            dataContext.Services.Update(service);
            await dataContext.SaveChangesAsync();
            return Ok(service);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Services.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

