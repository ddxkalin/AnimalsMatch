using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pets.Data.Models;

namespace Pets.Data
{
    public class ApplicationRoleStore : RoleStore<
        ApplicationRole,
        PetsDbContext,
        string, Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>, Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>>
    {
        public ApplicationRoleStore(PetsDbContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string> CreateRoleClaim(ApplicationRole role, Claim claim) =>
            new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
    }
}
