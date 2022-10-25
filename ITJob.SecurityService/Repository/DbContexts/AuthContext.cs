using ITJob.SecurityService.Models;
using ITJob.SecurityService.Repository.Entities;

namespace ITJob.SecurityService.Repository.DbContexts
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("SqlConnectionString")
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}