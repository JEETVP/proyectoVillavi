using Microsoft.EntityFrameworkCore;
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

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCitiesAsync();
            await CheckCompanysAsync();
            await CheckClientsAsync();
            await CheckMechanicsAsync();
            await CheckSuppliersAsync();
            await CheckCarsAsync();
            await CheckServicesAsync();
            await CheckOrdersAsync();
        }

        private async Task CheckCountriesAsync()
        {
            throw new NotImplementedException();
        }

        private async Task CheckCompanysAsync()
        {
            throw new NotImplementedException();
        }

        private async Task CheckCitiesAsync()
        {
            throw new NotImplementedException();
        }

        private async Task CheckClientsAsync()
        {
            if (!dataContext.Clients.Any())
            {
                dataContext.Clients.Add(new Client { Name = "Juan", LastName = "Perez", Telephone = "1234567890", Email = "juan.perez@mail.com" });
                dataContext.Clients.Add(new Client { Name = "Maria", LastName = "Gomez", Telephone = "9876543210", Email = "maria.gomez@mail.com" });
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckMechanicsAsync()
        {
            if (!dataContext.Mechanics.Any())
            {
                dataContext.Mechanics.Add(new Mechanic { Name = "Carlos", LastName = "Hernandez" });
                dataContext.Mechanics.Add(new Mechanic { Name = "Ana", LastName = "Lopez" });
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckSuppliersAsync()
        {
            if (!dataContext.Suppliers.Any())
            {
                dataContext.Suppliers.Add(new Supplier { Name = "Refacciones Puebla", Address = "Av. Central #123" });
                dataContext.Suppliers.Add(new Supplier { Name = "AutoPartes México", Address = "Calle Norte #456" });
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckCarsAsync()
        {
            if (!dataContext.Cars.Any())
            {
                var client = await dataContext.Clients.FirstOrDefaultAsync();
                if (client != null)
                {
                    dataContext.Cars.Add(new Car { Plate = "ABC123", Year = 2020, Model = "Civic", Brand = "Honda", Client = client });
                    dataContext.Cars.Add(new Car { Plate = "XYZ789", Year = 2021, Model = "Corolla", Brand = "Toyota", Client = client });
                    await dataContext.SaveChangesAsync();
                }
            }
        }

        private async Task CheckServicesAsync()
        {
            if (!dataContext.Services.Any())
            {
                var car = await dataContext.Cars.FirstOrDefaultAsync();
                var mechanic = await dataContext.Mechanics.FirstOrDefaultAsync();

                if (car != null && mechanic != null)
                {
                    dataContext.Services.Add(new Service
                    {
                        Name = "Cambio de Aceite",
                        ServiceType = "Mantenimiento",
                        Observations = "Usar aceite sintético",
                        SubServiceName = "Aceite", // Propiedad requerida por DetailService
                        Cost = 600,               // Propiedad requerida por DetailService
                        Car = car,
                        Mechanic = mechanic
                    });

                    dataContext.Services.Add(new Service
                    {
                        Name = "Revisión de Frenos",
                        ServiceType = "Reparación",
                        Observations = "Cambiar pastillas",
                        SubServiceName = "Frenos", // Propiedad requerida por DetailService
                        Cost = 800,               // Propiedad requerida por DetailService
                        Car = car,
                        Mechanic = mechanic
                    });

                    await dataContext.SaveChangesAsync();
                }
            }
        }



        private async Task CheckOrdersAsync()
        {
            if (!dataContext.Orders.Any())
            {
                var mechanic = await dataContext.Mechanics.FirstOrDefaultAsync();
                var supplier = await dataContext.Suppliers.FirstOrDefaultAsync();

                if (mechanic != null && supplier != null)
                {
                    dataContext.Orders.Add(new Order { OrderName = "Pedido Frenos", Pieces = "Pastillas de freno", Cost = 1500, Mechanic = mechanic, Supplier = supplier });
                    dataContext.Orders.Add(new Order { OrderName = "Pedido Aceite", Pieces = "Aceite sintético", Cost = 800, Mechanic = mechanic, Supplier = supplier });
                    await dataContext.SaveChangesAsync();
                }
            }
        }
    }
}
