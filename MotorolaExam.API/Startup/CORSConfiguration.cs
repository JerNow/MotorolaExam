namespace MotorolaExam.API.Startup
{
   public static class CORSConfiguration
   {
      public static WebApplicationBuilder AddCustomCors(this WebApplicationBuilder builder)
      {
         builder.Services.AddCors(o => o.AddDefaultPolicy(builder =>
         {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
         }));
         return builder;
      }
   }
}
