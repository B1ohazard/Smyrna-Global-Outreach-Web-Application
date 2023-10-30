using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smyrna_Prototype.Models
{
    public class Produce
    {
        // Table containing the product details -> Entered into DB
        [Key]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Enter the Name")]
        public string? ProductName { get; set; }

        [DisplayName("Product Description")]
        [Required(ErrorMessage = "Enter the Description")]
        public string? ProductDescription { get; set; }

        [DisplayName("Product Qauntity")]
        [Required(ErrorMessage = "Enter the Quantity")]
        public int ProductQuantity { get; set; }

        public string? Title { get; set; }

        [DisplayName("Image Name")]
        public string? ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        [Required(ErrorMessage = "Please add an Image")]
        public IFormFile? ImageFile { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Select a Date")]
        public DateTime Date { get; set; }

    }
}
