using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotorolaExam.AuthDB.Context;

namespace MotorolaExam.API.Startup
{
   public static class DependencyInjectionSetup
   {
      public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
      {
         builder.Services.AddDbContext<AuthorizationDbContext>(options => options.UseSqlServer(builder.Configuration["AuthorizationDbContext"]));

         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();

         builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                  .AddRoles<IdentityRole>()
                  .AddEntityFrameworkStores<AuthorizationDbContext>();


         return builder;
      }
   }
}
