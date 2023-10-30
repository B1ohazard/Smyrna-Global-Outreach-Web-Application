namespace Smyrna_Prototype.Models
{
    public interface IProductRepository
    {
        // IEnumerable to get all products from database
        IEnumerable<Produce> GetAllProducts { get; }

        // How do we want to fetch this data --> Using product ID (Primary Key)
        Produce GetProductById(int productId);
    }
}
