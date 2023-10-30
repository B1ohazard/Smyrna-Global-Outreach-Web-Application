using Smyrna_Prototype.Models;

namespace Smyrna_Prototype.ViewModels
{
    public class ProductListViewModel
    {
        // Passing the product IEnumerable
        public IEnumerable<Produce>? Products { get; set; }
    }
}
