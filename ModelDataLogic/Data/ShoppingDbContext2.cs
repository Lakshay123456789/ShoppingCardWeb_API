using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelDataLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataLogic.Data
{
   public class ShoppingDbContext2: IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ShoppingDbContext2(DbContextOptions<ShoppingDbContext2> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                this.SeedUsers(modelBuilder);
              this.SeedRoles(modelBuilder);
              this.SeedUserRoles(modelBuilder);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                LockoutEnabled = false,
            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();


            user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");

            builder.Entity<ApplicationUser>().HasData(user);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { UserId = "b74ddd14-6340-4840-95c2-db12554843e5", RoleId = "fab4fac1-c546-41de-aebc-a14da6895711" }
                );

        }
        public DbSet<Product> Products { get; set; }

    }
}
