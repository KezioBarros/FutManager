using API.Configurations;
using Shared.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();
builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddJwtAuthenticationConfiguration(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseCors("AllowConfiguredOrigins");
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
