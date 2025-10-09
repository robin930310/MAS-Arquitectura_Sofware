using Microsoft.EntityFrameworkCore;
using UsabanaAPIrest.Datos;
using UsabanaAPIrest.Models;

namespace UsabanaAPIrest.Servicios
{
    /// <summary>
    /// Implementación del servicio de productos
    /// </summary>
    internal class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Count()
        {
            return await _dbContext.Products.CountAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.FromResult(_dbContext.Products);
        }

        public async Task<IEnumerable<Product>> GetPagination(int limit, int offset)
        {
            return await Task.FromResult(_dbContext.Products
                .Skip(offset)
                .Take(limit));
        }

        public async Task<Product> GetById(string id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<Product> Create(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task Update(string id, Product product)
        {
            Product current = await this.GetById(id);

            if (current is null)
            {
                throw new KeyNotFoundException();
            }

            current.Titulo = product.Titulo;
            current.Descripcion = product.Descripcion;


            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Product current = await this.GetById(id);

            if (current is null)
            {
                throw new KeyNotFoundException();
            }

            _dbContext.Products.Remove(current);

            await _dbContext.SaveChangesAsync();
        }
    }
}
