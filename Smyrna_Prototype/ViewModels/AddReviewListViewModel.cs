using Microsoft.AspNetCore.Mvc;
using Smyrna_Prototype.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Smyrna_Prototype.ViewModels
{
    public class AddReviewListViewModel
    {
        // Passing the review IEnumerable
        public IEnumerable<AddReview>? AddReviews { get; set; }
        [BindProperty(SupportsGet = true)]

        public IEnumerable<CustomerReview>? CustomerReviews { get; set; }


        [DisplayName("First Name")]
        [Required(ErrorMessage = "Enter your First Name")]
        public string? FName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Enter your Last Name")]
        public string? LName { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Enter your Email Address")]
        public string? Email { get; set; }

        [DisplayName("Review")]
        [Required(ErrorMessage = "Enter your Venue Review here")]
        public string? ReviewStr { get; set; }
    }
}
