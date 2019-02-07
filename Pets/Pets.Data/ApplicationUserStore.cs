using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pets.Data.Models;

namespace Pets.Data
{
    public class ApplicationUserStore : UserStore<
        ApplicationUser,
        ApplicationRole,
        PetsDbContext,
        string, Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>, Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>, Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>, Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>, Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>>
    {
        public ApplicationUserStore(PetsDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string> CreateUserRole(ApplicationUser user, ApplicationRole role)
        {
            return new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string> { RoleId = role.Id, UserId = user.Id };
        }

        protected override Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string> CreateUserClaim(ApplicationUser user, Claim claim)
        {
            var identityUserClaim = new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string> { UserId = user.Id };
            identityUserClaim.InitializeFromClaim(claim);
            return identityUserClaim;
        }

        protected override Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string> CreateUserLogin(ApplicationUser user, UserLoginInfo login) =>
            new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };

        protected override Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string> CreateUserToken(
            ApplicationUser user,
            string loginProvider,
            string name,
            string value)
        {
            var token = new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
            return token;
        }
    }
}
