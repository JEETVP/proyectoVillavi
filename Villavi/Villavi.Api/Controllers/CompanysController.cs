using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villavi.Api.Migrations;
using Villavi.Shared.Entities;

namespace Villavi.Api.Controllers
{
    [ApiController]
    [Route("/api/companys")]
    public class CompanysController : ControllerBase
    {
        private readonly DataContext dataContext;

        public CompanysController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Companys.Include(c => c.City).ThenInclude(c => c.Country).ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var company = await dataContext.Companys.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Company company)
        {
            dataContext.Companys.Add(company);
            await dataContext.SaveChangesAsync();
            return Ok(company);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Company company)
        {
            dataContext.Companys.Update(company);
            await dataContext.SaveChangesAsync();
            return Ok(company);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var afectedRows = await dataContext.Companys.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
