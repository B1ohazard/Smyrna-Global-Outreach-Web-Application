using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smyrna_Prototype.Models
{
    public class CustomerReview
    {
        // Table containing the donation details -> Entered into DB
        [Key]
        public int ReviewId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Enter your First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Enter your Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Enter your Email Address")]
        public string? EmailAddress { get; set; }

        [DisplayName("Review")]
        [Required(ErrorMessage = "Enter your Venue Review here")]
        public string? Review { get; set; }

        [DisplayName("Is Posted")]
        public bool IsPosted { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [NotMapped]
        public IEnumerable<CustomerReview>? CustomerReviews { get; set; }
    }
}
