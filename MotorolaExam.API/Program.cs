using MotorolaExam.API.Startup;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
   s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

// Add services to the container.
builder.RegisterServices();
builder.AddCustomAuthentication();
builder.AddCustomSwagger();
builder.AddCustomCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
