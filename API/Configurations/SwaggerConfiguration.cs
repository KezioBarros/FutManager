using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                ConfigureSwaggerDoc(options);
                ConfigureXmlComments(options);
            });
        }

        private static void ConfigureSwaggerDoc(SwaggerGenOptions options)
        {
            options.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "FUTEBOL - API",
                    Version = "v1",
                    Description =
                        "API para gerenciamento de horários e usuários do sistema Futebol.",
                    Contact = new OpenApiContact
                    {
                        Name = "Kezio Barros",
                        Email = "keziopb@gmail.com",
                        Url = new Uri("https://github.com/KezioBarros"),
                    },
                }
            );
        }

        private static void ConfigureXmlComments(SwaggerGenOptions options)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var basePath = AppContext.BaseDirectory;

            var xmlFiles = assembly
                .GetReferencedAssemblies()
                .Union(new[] { assembly.GetName() })
                .Select(a => Path.Combine(basePath, $"{a.Name}.xml"))
                .Where(File.Exists)
                .ToList();

            foreach (var xml in xmlFiles)
                options.IncludeXmlComments(xml);
        }

        public static void UseSwaggerConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Futebol v1");
                });
            }
        }
    }
}
