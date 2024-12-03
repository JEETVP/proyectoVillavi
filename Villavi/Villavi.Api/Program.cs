using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Villavi.Shared.Entities;

namespace Villavi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Registrar el DbContext con la cadena de conexión del archivo appsettings.json
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

            // Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=con"));
            builder.Services.AddTransient<Seeder>();
            builder.Services.AddIdentity<User, IdentityRole>(x =>
            {
                x.User.RequireUniqueEmail = true;
                x.Password.RequireDigit = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequiredLength = 6;
            })
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

            var app = builder.Build();
            SeedApp(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.UseAuthentication();    

            app.MapControllers();

            app.Run();
        }

        private static void SeedApp(WebApplication app)
        {
            IServiceScopeFactory? serviceScopeFactory = app.Services.GetService<IServiceScopeFactory>();
            using (IServiceScope? serviceScope = serviceScopeFactory!.CreateScope())
            {
                Seeder? seeder = serviceScope.ServiceProvider.GetService<Seeder?>();
                seeder!.SeedAsync().Wait();
            }
        }
    }
}

