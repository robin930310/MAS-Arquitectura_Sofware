using System.ComponentModel.DataAnnotations;

namespace UsabanaAPIrest.Models
{

    /// <summary>
    /// Representa un producto dentro del sistema.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public string Id { get; internal set; } = Guid.NewGuid().ToString("N")[..8];

        /// <summary>
        /// Título o nombre del producto.
        /// </summary>
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Descripción detallada del producto.
        /// </summary>
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Precio del producto, incluyendo monto y moneda.
        /// </summary>
        public Price Precio { get; set; }

        /// <summary>
        /// Condición del producto. Valores permitidos: "Nuevo", "Usado".
        /// </summary>
        [AllowedValues("Nuevo", "Usado")]
        public string Condicion { get; set; } = "Nuevo";

        /// <summary>
        /// Colección de atributos personalizados asociados al producto.
        /// </summary>
        public ICollection<Attribute> Atributos { get; set; } = [];
    }
}
