using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotorolaExam.AuthDB.Context.Seeder;

namespace MotorolaExam.AuthDB.Context
{
   public class AuthorizationDbContext : IdentityDbContext
   {
      public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options)
          : base(options)
      {
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
         base.OnModelCreating(builder);
         builder.SeedDB();
      }
   }
}
