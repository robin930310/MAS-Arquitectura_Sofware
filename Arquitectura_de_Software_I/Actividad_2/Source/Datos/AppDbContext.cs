using Microsoft.EntityFrameworkCore;
using UsabanaAPIrest.Models;

namespace UsabanaAPIrest.Datos
{
    /// <summary>
    /// Contexto de base de datos principal para la aplicación UsabanaAPIrest.
    /// Gestiona el acceso y la configuración de las entidades del dominio.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Conjunto de productos disponibles en la base de datos.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="AppDbContext"/> con las opciones especificadas.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto de base de datos.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configura el modelo de datos y realiza la siembra inicial de productos, precios y atributos personalizados.
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos de Entity Framework utilizado para definir la estructura de las entidades y sus relaciones.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasData(
                    new Product
                    {
                        Id = "P0001",
                        Titulo = "iPhone 15 Pro Max 256GB Titanio Natural",
                        Descripcion = "El iPhone 15 Pro Max representa lo último en innovación de Apple. Con su chip A17 Pro, cámara de 48MP y diseño en titanio, ofrece una experiencia premium incomparable.",
                        Condicion = "Nuevo"
                    },
                    new Product
                    {
                        Id = "P0002",
                        Titulo = "Samsung Galaxy S24 Ultra 512GB Negro",
                        Descripcion = "El Samsung Galaxy S24 Ultra con S Pen integrada, cámara de 200MP y procesador Snapdragon 8 Gen 3. La experiencia definitiva en Android.",
                        Condicion = "Nuevo"
                    },
                    new Product
                    {
                        Id = "P0003",
                        Titulo = "MacBook Air M3 13 pulgadas 256GB Space Gray",
                        Descripcion = "MacBook Air con chip M3, hasta 18 horas de batería y diseño ultraligero. Perfecta para trabajo y creatividad.",
                        Condicion = "Usado"
                    },
                    new Product
                    {
                        Id = "P0004",
                        Titulo = "PlayStation 5 825GB Standard Blanco",
                        Descripcion = "PlayStation 5 con SSD ultrarrápido, ray tracing y compatibilidad con PS4. La nueva generación de gaming.",
                        Condicion = "Nuevo"
                    },
                    new Product
                    {
                        Id = "P0005",
                        Titulo = "Xbox Series X 1TB Negro",
                        Descripcion = "Xbox Series X con potencia de próxima generación, soporte 4K real y miles de juegos retrocompatibles. La consola más potente de Microsoft.",
                        Condicion = "Usado"
                    },
                    new Product
                    {
                        Id = "P0006",
                        Titulo = "Apple Watch Ultra 2 49mm Titanio",
                        Descripcion = "El Apple Watch Ultra 2 combina resistencia y precisión con GPS de doble frecuencia, pantalla brillante y batería para aventuras de todo el día.",
                        Condicion = "Nuevo"
                    },
                    new Product
                    {
                        Id = "P0007",
                        Titulo = "iPad Pro M4 12.9 pulgadas 256GB Plateado",
                        Descripcion = "iPad Pro con chip M4 y pantalla OLED Ultra Retina XDR. Potencia profesional en un diseño delgado y elegante.",
                        Condicion = "Nuevo"
                    },
                    new Product
                    {
                        Id = "P0008",
                        Titulo = "Sony WH-1000XM5 Audífonos Inalámbricos",
                        Descripcion = "Los Sony WH-1000XM5 ofrecen la mejor cancelación de ruido del mercado, hasta 30 horas de batería y sonido de alta fidelidad.",
                        Condicion = "Nuevo"
                    },
                    new Product
                    {
                        Id = "P0009",
                        Titulo = "DJI Mini 4 Pro Drone 4K",
                        Descripcion = "El DJI Mini 4 Pro ofrece grabación 4K HDR, sensores de obstáculos omnidireccionales y vuelo inteligente. Potente y compacto.",
                        Condicion = "Usado"
                    },
                    new Product
                    {
                        Id = "P0010",
                        Titulo = "Nintendo Switch OLED Blanca",
                        Descripcion = "Nintendo Switch OLED con pantalla de 7 pulgadas, mejor audio y base mejorada. Diversión portátil y doméstica en un solo dispositivo.",
                        Condicion = "Usado"
                    }
                );

                entity.OwnsOne(p => p.Precio, a =>
                {
                    a.WithOwner().HasForeignKey(b => b.ProductoId);
                    a.HasData(
                        new Price("P0001", 6999000m, "COP"),
                        new Price("P0002", 6499000m, "COP"),
                        new Price("P0003", 5999000m, "COP"),
                        new Price("P0004", 3899000m, "COP"),
                        new Price("P0005", 3699000m, "COP"),
                        new Price("P0006", 3899000m, "COP"),
                        new Price("P0007", 6899000m, "COP"),
                        new Price("P0008", 1699000m, "COP"),
                        new Price("P0009", 4599000m, "COP"),
                        new Price("P0010", 1849000m, "COP")
                    );
                });

                entity.OwnsMany(p => p.Atributos, a =>
                {
                    a.WithOwner().HasForeignKey(b => b.ProductoId);
                    a.HasData(
                        // P0001 - iPhone
                        new Models.Attribute("P0001", "Marca", "Apple"),
                        new Models.Attribute("P0001", "Modelo", "iPhone 15 Pro Max"),
                        new Models.Attribute("P0001", "Capacidad de almacenamiento", "256 GB"),
                        new Models.Attribute("P0001", "Color", "Titanio Natural"),

                        // P0002 - Samsung
                        new Models.Attribute("P0002", "Marca", "Samsung"),
                        new Models.Attribute("P0002", "Modelo", "Galaxy S24 Ultra"),
                        new Models.Attribute("P0002", "Capacidad de almacenamiento", "512 GB"),
                        new Models.Attribute("P0002", "Color", "Negro"),

                        // P0003 - MacBook
                        new Models.Attribute("P0003", "Marca", "Apple"),
                        new Models.Attribute("P0003", "Modelo", "MacBook Air M3"),
                        new Models.Attribute("P0003", "Capacidad de almacenamiento", "256 GB"),
                        new Models.Attribute("P0003", "Color", "Space Gray"),
                        new Models.Attribute("P0003", "Tamaño de pantalla", "13 pulgadas"),

                        // P0004 - PlayStation 5
                        new Models.Attribute("P0004", "Marca", "Sony"),
                        new Models.Attribute("P0004", "Modelo", "PlayStation 5"),
                        new Models.Attribute("P0004", "Capacidad de almacenamiento", "825 GB"),
                        new Models.Attribute("P0004", "Color", "Blanco"),

                        // P0005 - Xbox Series X
                        new Models.Attribute("P0005", "Marca", "Microsoft"),
                        new Models.Attribute("P0005", "Modelo", "Xbox Series X"),
                        new Models.Attribute("P0005", "Capacidad de almacenamiento", "1 TB"),
                        new Models.Attribute("P0005", "Color", "Negro"),

                        // P0006 - Apple Watch Ultra 2
                        new Models.Attribute("P0006", "Marca", "Apple"),
                        new Models.Attribute("P0006", "Modelo", "Watch Ultra 2"),
                        new Models.Attribute("P0006", "Tamaño", "49 mm"),
                        new Models.Attribute("P0006", "Material", "Titanio"),

                        // P0007 - iPad Pro M4
                        new Models.Attribute("P0007", "Marca", "Apple"),
                        new Models.Attribute("P0007", "Modelo", "iPad Pro M4"),
                        new Models.Attribute("P0007", "Tamaño de pantalla", "12.9 pulgadas"),
                        new Models.Attribute("P0007", "Capacidad de almacenamiento", "256 GB"),
                        new Models.Attribute("P0007", "Color", "Plateado"),

                        // P0008 - Sony WH-1000XM5
                        new Models.Attribute("P0008", "Marca", "Sony"),
                        new Models.Attribute("P0008", "Modelo", "WH-1000XM5"),
                        new Models.Attribute("P0008", "Tipo", "Audífonos Inalámbricos"),
                        new Models.Attribute("P0008", "Cancelación de ruido", "Sí"),
                        new Models.Attribute("P0008", "Autonomía", "30 horas"),

                        // P0009 - DJI Mini 4 Pro
                        new Models.Attribute("P0009", "Marca", "DJI"),
                        new Models.Attribute("P0009", "Modelo", "Mini 4 Pro"),
                        new Models.Attribute("P0009", "Resolución de video", "4K HDR"),
                        new Models.Attribute("P0009", "Peso", "< 249 g"),
                        new Models.Attribute("P0009", "Sensores", "Omnidireccionales"),

                        // P0010 - Nintendo Switch OLED
                        new Models.Attribute("P0010", "Marca", "Nintendo"),
                        new Models.Attribute("P0010", "Modelo", "Switch OLED"),
                        new Models.Attribute("P0010", "Color", "Blanco"),
                        new Models.Attribute("P0010", "Tamaño de pantalla", "7 pulgadas"),
                        new Models.Attribute("P0010", "Tipo", "Consola Híbrida")
                    );
                });
            });
        }
    }
}
