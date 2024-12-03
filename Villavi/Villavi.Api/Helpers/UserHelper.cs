using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Villavi.Shared.Entities;

namespace Villavi.Api.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext dataContext;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserHelper(DataContext dataContext, UserManager <User> userManager, RoleManager <IdentityRole> roleManager)
        {
            this.dataContext = dataContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> IUserHelper.AdduserAsync(User user, string password)

        {
            return await userManager.CreateAsync (user, password);
        }

        public async Task IUserHelper.AddUserToRoleASync(User user, string roleName)

        {
            await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task IUserHelper.CheckRoleAsync(string roleName)

        {
            bool roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = roleName, });
            }
        }

        public async  Task<User> IUserHelper.GetUserAsync(string email)
        {
            var user = await dataContext.Users.Include(u => u.City).FirstOrDefaultAsync(x => x.Email == email)
            return user;
        }

        async Task<bool> IUserHelper.IsUserInRolAsync(User user, string roleName)
        {  
        }
    }
}
