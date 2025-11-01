using API.Configurations;
using MDA.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();
builder.Services.AddCorsConfiguration();
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();
app.UseCors("AllowAnyOrigin");
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
