using MotorolaExam.API.Startup;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Add services to the container.
builder.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
