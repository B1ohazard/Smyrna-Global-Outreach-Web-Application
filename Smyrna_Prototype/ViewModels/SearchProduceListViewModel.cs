using Microsoft.AspNetCore.Mvc;
using Smyrna_Prototype.Models;

namespace Smyrna_Prototype.ViewModels
{
    public class SearchProduceListViewModel
    {
        // The product search variables
        public IEnumerable<Produce>? Products { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchProductTypeString { get; set; }
    }
}
