using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Smyrna_Prototype.Models
{
	public class Enquiry
	{
		// Table containing the Enquiry details -> Entered into DB
		[Key]
		public int EnquiryId { get; set; }

		[DisplayName("First Name")]
        [Required(ErrorMessage = "Enter your First Name")]
        public string? FirstName { get; set; }

		[DisplayName("Last Name")]
        [Required(ErrorMessage = "Enter your Last Name")]
        public string? LastName { get; set; }

		[DisplayName("Email Address")]
        [Required(ErrorMessage = "Enter your Email Address")]
        public string? EmailAddress { get; set; }

		[DisplayName("Contact Number")]
        [Required(ErrorMessage = "Enter your Contact Number")]
        public string? ContactNumber { get; set; }

		[DisplayName("Message")]
        [Required(ErrorMessage = "Enter a Message to let us know how we can help")]
        public string? Message { get; set; }

		[DisplayName("Date")]
		public DateTime Date { get; set; }
	}
}
