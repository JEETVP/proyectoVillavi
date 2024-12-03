
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Villavi.Shared.Entities;

namespace Villavi.Api
{
    public class Seeder
    {
        private readonly DataContext dataContext;
        public Seeder(DataContext dataContext)
        { 
            this.dataContext = dataContext;
        }
        public async Task SeedAsync ()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCitiesAsync();
            await CheckCompanysAsync();
        }

        private async Task CheckCompanysAsync()
        {
            if (!dataContext.Companys.Any())
            {
                var city = await dataContext.Cities.FirstOrDefaultAsync(x => x.Name == "Puebla");
                if (city != null)
                {
                    dataContext.Companys.Add(new Company { Name = "SKF", City = city });
                    dataContext.Companys.Add(new Company { Name = "Tsystems", City = city });
                    dataContext.Companys.Add(new Company { Name = "Pregat", City = city });
                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckCitiesAsync()
        {
            if (!dataContext.Cities.Any())
            {
                var country = await dataContext.Countries.FirstOrDefaultAsync(x => x.Name =="Mexico");
                if (country != null)
                {
                    dataContext.Cities.Add(new City { Name = "Puebla", Country = country });
                    dataContext.Cities.Add(new City { Name = "Cholula", Country= country });    
                    dataContext.Cities.Add(new City { Name = "Tepeaca", Country=country }); 
                    dataContext.Cities.Add(new City { Name = "San Martin",Country= country });

                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!dataContext.Countries.Any())
            {
                dataContext.Countries.Add(new Country { Name = "Mexico" });
                dataContext.Countries.Add(new Country { Name = "Peru" });
                dataContext.Countries.Add(new Country { Name = "USA" });
                dataContext.Countries.Add(new Country { Name = "Brazil" });
                await dataContext.SaveChangesAsync();   
            }
        }
    }
}
