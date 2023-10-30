using System;

namespace Smyrna_Prototype.Models
{
    public class ProduceRepository : IProductRepository
    {
        // private readonly variable to access the database
        private readonly AppDbContext _appDbContext;

        public ProduceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // IEnumerable to get all products from database
        public IEnumerable<Produce> GetAllProducts => _appDbContext.Products;

        public Produce GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
