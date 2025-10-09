using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using UsabanaAPIrest.Models;
using UsabanaAPIrest.Servicios;


namespace UsabanaAPIrest.Controllers
{
    /// <summary>
    /// Controlador para la gestión de productos.
    /// Proporciona endpoints para operaciones CRUD sobre productos.
    /// </summary>
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion(1, Deprecated = true)]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public partial class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ProductsController"/>.
        /// </summary>
        /// <param name="productService">Servicio de productos inyectado.</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Obtiene todos los productos disponibles.
        /// </summary>
        /// <returns>Lista total de productos.</returns>
        /// <response code="200">Lista de productos obtenida exitosamente.</response>
        [HttpGet]
        [MapToApiVersion(1)]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetAll());
        }

        /// <summary>
        /// Obtiene un producto específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del producto.</param>
        /// <returns>El producto solicitado si existe.</returns>
        /// <response code="200">Producto encontrado.</response>
        /// <response code="404">Producto no encontrado.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            Product product = await _productService.GetById(id);

            if (product is null)
            {
                return Problem(
                    statusCode: StatusCodes.Status404NotFound,
                    detail: $"Producto con el identificador {id} no existe");
            }

            return Ok(product);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="product">Entidad del producto a crear.</param>
        /// <returns>El producto creado y su ubicación.</returns>
        /// <response code="201">Producto creado exitosamente.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            product = await _productService.Create(product);
            return CreatedAtAction(nameof(GetProduct), new { product.Id }, product);
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto a actualizar.</param>
        /// <param name="product">Valor actualizado del producto.</param>
        /// <response code="204">Producto actualizado exitosamente</response>
        /// <response code="400">Identificador del producto no Existe</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(string id, [FromBody] Product product)
        {
            try
            {
                await _productService.Update(id, product);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return Problem(
                    statusCode: StatusCodes.Status404NotFound,
                    detail: $"Producto con el identificador {id} no existe");
            }
        }
    }


    /// <summary>
    /// Controlador para la gestión de productos.
    /// Proporciona endpoints para operaciones CRUD sobre productos.
    /// </summary>
    [ApiVersion(2)]
    public partial class ProductsController
    {
        /// <summary>
        /// Obtiene todos los productos disponibles con paginación.
        /// </summary>
        /// <param name="limit">Número máximo de productos por página (máximo 10).</param>
        /// <param name="page">Número de página</param>
        /// <returns>Lista paginada de productos.</returns>
        /// <response code="200">Lista de productos obtenida exitosamente.</response>
        /// <response code="400">El valor de 'limit' excede el máximo permitido.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion(2)]
        public async Task<IActionResult> GetProducts([FromQuery] int limit = 3, [FromQuery] int page = 1)
        {
            if (limit > 10)
            {
                return Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: "El máximo de registros a retornar es 10.");
            }

            if (page < 0)
            {
                return Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: "El numero de pagina es incorrecto");
            }

            double total = await _productService.Count();
            if (page > Math.Ceiling(total / limit))
            {
                return Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: "El numero de pagina es incorrecto");
            }

            Response.Headers.Append("x-total_pages", Math.Ceiling(total / limit).ToString());
            Response.Headers.Append("x-total_records", total.ToString());

            if (page < Math.Ceiling(total / limit))
            {
                Response.Headers.Append("x-next_page", Url.Action(nameof(GetProducts), new { limit, page = page + 1 }));
            }

            return Ok(await _productService.GetPagination(limit, (page - 1) * limit));
        }

        /// <summary>
        /// Elimina un producto por su identificador.
        /// </summary>
        /// <param name="id">Identificador del producto a eliminar.</param>
        /// <response code="204">Producto eliminado exitosamente</response>
        /// <response code="400">Identificador del producto no Existe</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [MapToApiVersion(2)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _productService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return Problem(
                    statusCode: StatusCodes.Status404NotFound,
                    detail: $"Producto con el identificador {id} no existe");
            }
        }
    }
}
