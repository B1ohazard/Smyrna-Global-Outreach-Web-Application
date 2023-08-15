using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Smyrna_Prototype.Models
{
    public class Donation
    {
        // Table containing the donation details -> Entered into DB
        [Key]
        public int DonationId { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Amount")]
        public int Amount { get; set; }

        [DisplayName("Company Name")]
        public string? CompanyName { get; set; }

		[DisplayName("Email Address")]
		public string? EmailAddress { get; set; }

		[DisplayName("Date")]
        public DateTime Date { get; set; }
    }
}
