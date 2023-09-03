using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Smyrna_Prototype.Models;

namespace Smyrna_Prototype.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;

        public ServicesController(AppDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerReview(CustomerReview customerReview)
        {
            customerReview.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailAsync(
                "fowlessean@yahoo.com",
                "Venue Review",
                "First Name: " + customerReview.FirstName + " |" +
                "Last Name: " + customerReview.LastName + " |" +
                "Last Name: " + customerReview.EmailAddress + " |" +
                "Message: " + customerReview.Review + " |" +
                "Date: " + customerReview.Date
                );

                _context.Add(customerReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VenueHire));
            }
            return View(customerReview);
        }

    }
}
