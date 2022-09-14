using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MotorolaExam.AuthDB.Context;
using MotorolaExam.EntitiesDb.Context;
using MotorolaExam.EntitiesDb.DAL.UnitOfWork;

namespace MotorolaExam.API.Startup
{
   public static class DependencyInjectionSetup
   {
      public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
      {
         builder.Services.AddDbContext<AuthorizationDbContext>(options => options.UseSqlServer(builder.Configuration["AuthorizationDbContext"]));
         builder.Services.AddDbContext<MotorolaExamEntitiesDbContext>(options => options.UseSqlServer(builder.Configuration["EduMaterialsDb"]));

         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();

         builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                  .AddRoles<IdentityRole>()
                  .AddEntityFrameworkStores<AuthorizationDbContext>();

         builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


         return builder;
      }
   }
}
