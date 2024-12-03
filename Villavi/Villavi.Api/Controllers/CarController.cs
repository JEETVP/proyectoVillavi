using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Villavi.Shared.Entities;

namespace Villavi.Api.Controllers
{
    [ApiController]
    [Route("/api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public CarsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Cars.ToListAsync());
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var car = await
                dataContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Car car)
        {
            dataContext.Cars.Add(car);
            await dataContext.SaveChangesAsync();
            return Ok(car);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Car car)
        {
            dataContext.Cars.Update(car);
            await dataContext.SaveChangesAsync();
            return Ok(car);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var afectedRows = await dataContext.Cars.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
