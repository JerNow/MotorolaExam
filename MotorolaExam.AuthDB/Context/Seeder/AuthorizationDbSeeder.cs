using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MotorolaExam.AuthDB.Context.Seeder
{
   public static class AuthorizationDbSeeder
   {
      public static void SeedDB(this ModelBuilder builder)
      {
         builder.SeedRoles();
         builder.SeedUsers();
         builder.SeedUserRoles();
      }
      private static void SeedUsers(this ModelBuilder builder)
      {
         IdentityUser user = new()
         {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            PhoneNumber = "1234567890",
            PhoneNumberConfirmed = true
         };

         PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
         user.PasswordHash = passwordHasher.HashPassword(user, "Admin123");

         builder.Entity<IdentityUser>().HasData(user);
      }

      private static void SeedRoles(this ModelBuilder builder)
      {
         builder.Entity<IdentityRole>().HasData(
             new IdentityRole() { Id = "0004fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
             new IdentityRole() { Id = "111d13f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
             );
      }

      private static void SeedUserRoles(this ModelBuilder builder)
      {
         builder.Entity<IdentityUserRole<string>>().HasData(
             new IdentityUserRole<string>() { RoleId = "0004fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
             );
      }
   }
}
