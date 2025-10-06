using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace UsabanaAPIrest.Models
{
    /// <summary>
    /// Representa el precio de un producto, incluyendo el monto y la moneda.
    /// </summary>
    [Owned]
    public class Price
    {
        /// <summary>
        /// Identificador único del precio. Se genera automáticamente.
        /// </summary>
        [JsonIgnore]
        public string Id { get; internal set; } = Guid.NewGuid().ToString("N")[..8];

        /// <summary>
        /// Identificador del producto asociado a este precio.
        /// </summary>
        [JsonIgnore]
        public string ProductoId { get; internal set; }

        /// <summary>
        /// Monto del precio.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Moneda en la que se expresa el precio. Valores permitidos: "COP", "US", "EUR".
        /// </summary>
        [AllowedValues("COP", "US", "EUR")]
        public string Moneda { get; set; } = "COP";

        /// <summary>
        /// Constructor por defecto requerido por Entity Framework.
        /// </summary>
        public Price() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Price"/> con los valores especificados.
        /// </summary>
        /// <param name="productoId">Identificador del producto.</param>
        /// <param name="monto">Monto del precio.</param>
        /// <param name="moneda">Moneda del precio.</param>
        public Price(string productoId, decimal monto, string moneda)
        {
            ProductoId = productoId;
            Monto = monto;
            Moneda = moneda;
        }
    }
}
