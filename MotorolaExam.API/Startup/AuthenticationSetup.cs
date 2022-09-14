using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MotorolaExam.API.Startup
{
   public static class AuthenticationSetup
   {
      public static WebApplicationBuilder AddCustomAuthentication(this WebApplicationBuilder builder)
      {
         builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
         {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidAudience = builder.Configuration["Jwt:Audience"],
               ValidIssuer = builder.Configuration["Jwt:Issuer"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
         });

         return builder;
      }
   }
}
