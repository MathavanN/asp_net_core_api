using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Models;

namespace Supermarket.Core.Context
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Initialize Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Name = "Customer", NormalizedName = "Customer".ToUpper() });
        }
    }
}
