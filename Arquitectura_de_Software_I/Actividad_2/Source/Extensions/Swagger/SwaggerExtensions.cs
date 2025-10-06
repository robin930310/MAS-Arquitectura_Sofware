using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using UsabanaAPIrest.Options.Swagger;

namespace UsabanaAPIrest.Extensions.Swagger
{
    /// <summary>
    /// Proporciona métodos de extensión para configurar y utilizar Swagger/OpenAPI en la aplicación.
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Configura los servicios necesarios para OpenAPI (Swagger), incluyendo la generación de documentación,
        /// el versionado de la API y la inclusión de comentarios XML.
        /// </summary>
        /// <param name="builder">El <see cref="WebApplicationBuilder"/> de la aplicación.</param>
        /// <returns>El <see cref="WebApplicationBuilder"/> con los servicios configurados.</returns>
        public static WebApplicationBuilder ConfigureOpenApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version"));
            })
                .AddMvc()
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });

            builder.Services.AddSwaggerGen(c =>
            {
                string docfile = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                if (File.Exists(docfile))
                {
                    c.IncludeXmlComments(docfile);
                }
            });

            return builder;
        }

        /// <summary>
        /// Habilita el middleware de Swagger y la interfaz de usuario de SwaggerUI en la aplicación.
        /// Configura los endpoints de Swagger para cada versión de la API.
        /// </summary>
        /// <param name="app">La instancia de <see cref="WebApplication"/>.</param>
        /// <returns>La instancia de <see cref="WebApplication"/> con Swagger habilitado.</returns>
        public static WebApplication UseOpenApi(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.InjectJavascript("/swagger-extra.js");

                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}
