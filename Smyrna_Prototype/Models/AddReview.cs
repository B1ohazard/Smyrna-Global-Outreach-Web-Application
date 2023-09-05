using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Smyrna_Prototype.Models
{
    public class AddReview
    {
        // Table containing the donation details -> Entered into DB
        [Key]
        public int AddReviewId { get; set; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Enter the Customers Full Name")]
        public string? CustomerName { get; set; }

        [DisplayName("Customers Review")]
        [Required(ErrorMessage = "Enter the Customers Review Here")]
        public string? CustomerReview { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }
    }
}
