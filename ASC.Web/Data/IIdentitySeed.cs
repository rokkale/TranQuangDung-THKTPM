using ASC.Web.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ASC.Web.Data
{
    public interface IIdentitySeed
    {
        Task Seed(UserManager<IdentityUser> UserManager, RoleManager<IdentityRole> roleManager, IOptions<ApplicationSettings>options);
    }
}
