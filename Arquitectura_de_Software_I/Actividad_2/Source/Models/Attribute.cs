using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace UsabanaAPIrest.Models
{
    /// <summary>
    /// Representa un atributo personalizado asociado a un producto.
    /// </summary>
    [Owned]
    public class Attribute
    {
        /// <summary>
        /// Identificador único del atributo (no expuesto en la serialización JSON).
        /// </summary>
        [JsonIgnore]
        public string Id { get; internal set; } = Guid.NewGuid().ToString("N")[..8];

        /// <summary>
        /// Identificador del producto al que pertenece este atributo (no expuesto en la serialización JSON).
        /// </summary>
        [JsonIgnore]
        public string ProductoId { get; internal set; }

        /// <summary>
        /// Nombre del atributo.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripción del atributo.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Constructor por defecto requerido por Entity Framework.
        /// </summary>
        public Attribute() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Attribute"/> con los valores especificados.
        /// </summary>
        /// <param name="productoId">Identificador del producto asociado.</param>
        /// <param name="name">Nombre del atributo.</param>
        /// <param name="description">Descripción del atributo.</param>
        public Attribute(string productoId, string name, string description)
        {
            ProductoId = productoId;
            Name = name;
            Description = description;
        }
    }
}
