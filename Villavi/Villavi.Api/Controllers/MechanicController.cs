using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villavi.Shared.Entities;

namespace Villavi.Api.Controllers
{
    [ApiController]
    [Route("/api/mechanics")]
    public class MechanicController : ControllerBase
    {
        private readonly DataContext dataContext;

        public MechanicController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Mechanics.ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var mechanic = await
                dataContext.Mechanics.FirstOrDefaultAsync(x => x.Id == id);
            if (mechanic == null)
            {
                return NotFound();
            }
            return Ok(mechanic);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Mechanic mechanic)
        {
            dataContext.Mechanics.Add(mechanic);
            await dataContext.SaveChangesAsync();
            return Ok(mechanic);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Mechanic mechanic)
        {
            dataContext.Mechanics.Update(mechanic);
            await dataContext.SaveChangesAsync();
            return Ok(mechanic);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Mechanics.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

