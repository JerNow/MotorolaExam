using Microsoft.OpenApi.Models;

namespace MotorolaExam.API.Startup
{
   public static class SwaggerConfiguration
   {
      public static WebApplication ConfigureSwagger(this WebApplication app)
      {


         if (app.Environment.IsDevelopment())
         {
            app.UseSwagger();
            app.UseSwaggerUI();
         }

         return app;
      }

      public static WebApplicationBuilder AddCustomSwagger(this WebApplicationBuilder builder)
      {
         builder.Services.AddSwaggerGen(c =>
         {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
               Name = "Authorization",
               Type = SecuritySchemeType.ApiKey,
               Scheme = "Bearer",
               BearerFormat = "JWT",
               In = ParameterLocation.Header,
               Description = "Bearer Authorization",
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string [] {}
                }
            });
         });

         return builder;
      }
   }
}
