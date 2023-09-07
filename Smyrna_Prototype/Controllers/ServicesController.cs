using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Smyrna_Prototype.Migrations;
using Smyrna_Prototype.Models;
using Smyrna_Prototype.ViewModels;

namespace Smyrna_Prototype.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly ICustomerReviewRepository customerReviewRepository;

        public ServicesController(AppDbContext context, IEmailSender emailSender, ICustomerReviewRepository customerReviewRepository)
        {
            _context = context;
            _emailSender = emailSender;
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

        public IActionResult CustomerReviews()
        {
            var customerReviewsList = new CustomerReview();
            customerReviewsList.CustomerReviews = customerReviewRepository.GetCustomerReviews;

            return View(customerReviewsList);
        }

        public IActionResult VenueHire()
        {
            var customerReviewsList = new CustomerReview();
            customerReviewsList.CustomerReviews = customerReviewRepository.GetCustomerReviews;

            return View(customerReviewsList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VenueHire(CustomerReview customerReview)
        {
            if (ModelState.IsValid)
            {
                customerReview.Date = DateTime.Now;
                customerReview.IsPosted = false;

                await _emailSender.SendEmailAsync(
                   "fowlessean@yahoo.com",
                   "Venue Review",
                   "You have a new Venue Review! Please check the website for details"
                   );

                _context.Add(customerReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VenueHire));
            }
            return View();
        }

        public async Task<IActionResult> PostReview(int? id)
        {
            if (id == null || _context.CustomerReviews == null)
            {
                return NotFound();
            }

            var review = await _context.CustomerReviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostReview(int id, CustomerReview customerReview)
        {
            if (id != customerReview.ReviewId)
            {
                return NotFound();
            }

            /* if (ModelState.IsValid)
             {*/
            try
                {
                    _context.Update(customerReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(customerReview.ReviewId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(CustomerReviews));
               
            }
        /*    return RedirectToAction(nameof(CustomerReviews));
        }*/

        private bool ReviewExists(int id)
        {
            return (_context.CustomerReviews?.Any(r => r.ReviewId == id)).GetValueOrDefault();
        }
    }
}
