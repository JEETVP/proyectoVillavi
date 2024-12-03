using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villavi.Shared.Entities;

namespace Villavi.Api.Controllers
{
    [ApiController]
    [Route("/api/detailservices")]
    public class DetailServiceController : ControllerBase
    {
        private readonly DataContext dataContext;

        public DetailServiceController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Details.ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var detailService = await
                dataContext.Details.FirstOrDefaultAsync(x => x.Id == id);
            if (detailService == null)
            {
                return NotFound();
            }
            return Ok(detailService);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(DetailService detailService)
        {
            dataContext.Details.Add(detailService);
            await dataContext.SaveChangesAsync();
            return Ok(detailService);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(DetailService detailService)
        {
            dataContext.Details.Update(detailService);
            await dataContext.SaveChangesAsync();
            return Ok(detailService);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var affectedRows = await dataContext.Details.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
