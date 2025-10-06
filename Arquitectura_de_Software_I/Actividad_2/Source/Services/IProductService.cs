
using UsabanaAPIrest.Models;

namespace UsabanaAPIrest.Servicios
{
    /// <summary>
    /// Interfaz para el servicio de productos.
    /// Proporciona métodos para la gestión de productos en el sistema.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Obtiene la cantidad total de productos.
        /// </summary>
        /// <returns>Un entero que representa el número total de productos.</returns>
        Task<int> Count();

        /// <summary>
        /// Obtiene todos los productos registrados en el sistema.
        /// </summary>
        /// <returns>Una colección enumerable de productos.</returns>
        Task<IEnumerable<Product>> GetAll();

        /// <summary>
        /// Obtiene una lista paginada de productos.
        /// </summary>
        /// <param name="limit">Cantidad máxima de productos a devolver.</param>
        /// <param name="offset">Cantidad de productos a omitir antes de comenzar a devolver resultados.</param>
        /// <returns>Una colección enumerable de productos según la paginación especificada.</returns>
        Task<IEnumerable<Product>> GetPagination(int limit, int offset);

        /// <summary>
        /// Obtiene un producto por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del producto.</param>
        /// <returns>El producto correspondiente al identificador proporcionado.</returns>
        Task<Product> GetById(string id);

        /// <summary>
        /// Crea un nuevo producto en el sistema.
        /// </summary>
        /// <param name="product">El producto a crear.</param>
        /// <returns>El producto creado.</returns>
        Task<Product> Create(Product product);

        /// <summary>
        /// Actualiza la información de un producto existente.
        /// </summary>
        /// <param name="id">Identificador único del producto a actualizar.</param>
        /// <param name="product">Objeto producto con los datos actualizados.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task Update(string id, Product product);

        /// <summary>
        /// Elimina un producto del sistema por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del producto a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task Delete(string id);
    }
}
