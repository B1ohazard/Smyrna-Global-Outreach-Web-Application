using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Smyrna_Prototype.Migrations;
using Smyrna_Prototype.Models;
using Smyrna_Prototype.ViewModels;

namespace Smyrna_Prototype.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IAddReviewRepository reviewRepository;
        private readonly ICustomerReviewRepository customerReviewRepository;

        public ServicesController(AppDbContext context, IEmailSender emailSender, IAddReviewRepository reviewRepository, ICustomerReviewRepository customerReviewRepository)
        {
            _context = context;
            _emailSender = emailSender;
            this.reviewRepository = reviewRepository;
            this.customerReviewRepository = customerReviewRepository;
        }

        public IActionResult Rehabilitation()
        {
            return View();
        }

        public IActionResult MissionarySchool()
        {
            return View();
        }

        public IActionResult OtherServices()
        {
            return View();
        }

        public IActionResult VenueHire()
        {
            var addReviewListViewModel = new AddReviewListViewModel();
            addReviewListViewModel.AddReviews = reviewRepository.GetAllReviews;

            return View(addReviewListViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VenueHire(string FName, string LName, string Email, string ReviewStr, CustomerReview customerReview)
        {

            if (ModelState.IsValid)
            {
                CustomerReview custReview = new CustomerReview();
                custReview.FirstName = FName;
                custReview.LastName = LName;
                custReview.EmailAddress = Email;
                custReview.Review = ReviewStr;
                custReview.Date = DateTime.Now;

                await _emailSender.SendEmailAsync(
                   "fowlessean@yahoo.com",
                   "Venue Review Form",
                   "First Name: " + customerReview.FirstName + " |" +
                   "Last Name: " + customerReview.LastName + " |" +
                   "Email Address: " + customerReview.EmailAddress + " |" +
                   "Review: " + customerReview.Review + " |" +
                   "Review Date: " + customerReview.Date
                   );

                _context.Add(custReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VenueHire));
            }
            return View();
        }
    }
}
