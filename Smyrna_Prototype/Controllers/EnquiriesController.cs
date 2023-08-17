using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Smyrna_Prototype.Models;

namespace Smyrna_Prototype.Controllers
{
	public class EnquiriesController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IEmailSender _emailSender;

        public EnquiriesController(AppDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public IActionResult Contact()
		{
			return View();
		}

		// POST: Enquiries/Contact
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Contact(Enquiry enquiry)
		{
			enquiry.Date = DateTime.Now;

            if (ModelState.IsValid)
			{
                await _emailSender.SendEmailAsync(
                "fowlessean@yahoo.com",
				"Enquiry Form",
				"First Name: " + enquiry.FirstName + " |" +
				"Last Name: " + enquiry.LastName + " |" +
                "Contact Number: " + enquiry.ContactNumber + " |" +
                "Message: " + enquiry.Message + " |" +
                "Date: " + enquiry.Date 
                );

                _context.Add(enquiry);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Contact));
			}
			return View(enquiry);
		}
	}
}
