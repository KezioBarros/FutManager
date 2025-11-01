using API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();
builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();
app.UseCors("AllowConfiguredOrigins");
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
