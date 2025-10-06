using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UsabanaAPIrest.Options.Swagger
{
    /// <summary>
    /// Configura las opciones de Swagger para soportar la documentación de versiones de la API.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConfigureSwaggerOptions"/>.
        /// </summary>
        /// <param name="provider">Proveedor de descripciones de versiones de la API.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Configura las opciones de SwaggerGen para cada versión de la API.
        /// </summary>
        /// <param name="options">Opciones de SwaggerGen a configurar.</param>
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        /// <summary>
        /// Crea la información de OpenAPI para una versión específica de la API.
        /// </summary>
        /// <param name="apiVersionDescription">Descripción de la versión de la API.</param>
        /// <returns>Instancia de <see cref="OpenApiInfo"/> configurada para la versión de la API.</returns>
        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription apiVersionDescription)
        {
            var info = new OpenApiInfo
            {
                Title = "API Usabana",
                Version = apiVersionDescription.ApiVersion.ToString(),
                Description = "API de ejemplo con las caracteristicas 'OpenApi', 'RateLimit', 'ApiVersion', 'StatusCodes', 'HttpMethods' y 'Problem Details (rfc9457)'",
                Contact = new OpenApiContact
                {
                    Name = "Grupo #11 - MAS U.Sabana 2025",
                    Email = "ejemplo@correo.com"
                },
            };

            info.Contact.Extensions.Add("x-integrantes", new OpenApiArray
            {
                new OpenApiString("Daniel Francisco Sanchez Hernandez"),
                new OpenApiString("Roger Armando Meza Valiente"),
                new OpenApiString("David Ricardo Grandas Cardenas"),
                new OpenApiString("Robinson Castro Londoño"),
            });

            if (apiVersionDescription.IsDeprecated)
            {
                info.Description += " (Esta versión esta deprecada)";
            }

            return info;
        }
    }
}
