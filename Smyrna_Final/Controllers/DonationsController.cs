﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smyrna_Prototype.Models;

namespace Smyrna_Prototype.Controllers
{
    public class DonationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;

        public DonationsController(AppDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Donation donation)
        {
            donation.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailAsync(
                "fowlessean@yahoo.com",
                "Donation Form",
                "First Name: " + donation.FirstName + " |" +
                "Last Name: " + donation.LastName + " |" +
                "Company Name: " + donation.CompanyName + " |" +
                "Email Address: " + donation.EmailAddress + " |" +
                "Donation Date: " + donation.Date
                );

                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Donate));
            }
            return View(donation);
        }

        public IActionResult Donate()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


    }
}
