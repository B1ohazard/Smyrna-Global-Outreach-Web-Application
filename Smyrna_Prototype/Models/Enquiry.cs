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
		public string? FirstName { get; set; }

		[DisplayName("Last Name")]
		public string? LastName { get; set; }

		[DisplayName("Email Address")]
		public string? EmailAddress { get; set; }

		[DisplayName("Contact Number")]
		public string? ContactNumber { get; set; }

		[DisplayName("Message")]
		public string? Message { get; set; }

		[DisplayName("Date")]
		public DateTime Date { get; set; }
	}
}
