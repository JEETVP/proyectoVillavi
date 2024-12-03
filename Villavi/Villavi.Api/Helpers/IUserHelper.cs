using Microsoft.AspNetCore.Identity;
using Villavi.Shared.Entities;

namespace Villavi.Api.Helpers
{
    public interface IUserHelper
    {
         Task<User> GetUserAsync(string email);
         Task<IdentityResult> AdduserAsync(User user, string password);
         Task CheckRoleAsync(string roleName);
         Task AddUserToRoleASync(User user, string roleName);
         Task<bool> IsUserInRolAsync(User user, string roleName);

    }
}
