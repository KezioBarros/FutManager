using API.Configurations;
using API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();
builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);
builder.Services.AddJwtAuthenticationConfiguration(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseCors("AllowConfiguredOrigins");
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseGlobalException();
app.MapControllers();

app.Run();
